using CoboneMerchant.Services;
using CoboneMerchant.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.MessageHandlers
{
    public class BaseMessageHandler : DelegatingHandler
    {
        const int authorizationAttempts = 5;
        private readonly ICookie cookieService;
        private readonly IAuthorizationManager authorizationManager;

        public enum AuthorizationState
        {
            AuthorizationFailed = 0,
            AuthorizationInProgress = 1,
            AuthorizationSucceeded = 2,
        }

        public BaseMessageHandler(ICookie cookieService, IAuthorizationManager authorizationManager)
        {
            this.cookieService = cookieService??throw new ArgumentNullException(nameof(cookieService));
            this.authorizationManager = authorizationManager?? throw new ArgumentNullException(nameof(authorizationManager));
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            int authorizationAttemptsCount = 0;
            AuthorizationState authorizationState = AuthorizationState.AuthorizationFailed;
            HttpResponseMessage? response;
            do
            {
                //if no authorization cookie saved, use the dummy token to get unauthorized response and request a new token
                string cookie = await cookieService.GetValue("Authorization", " ");
                request.Headers.Add("X-Oc-Merchant-Language", CultureInfo.CurrentCulture.Name.Split('-')[0]);
                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    var cookieValues = cookie.Split(' ');
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(cookieValues[0], cookieValues[1]);
                }
                //request.Headers.Add("Authorization", cookie.Replace('\'',' '));
                response = await base.SendAsync(request, cancellationToken);
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    if (await authorizationManager.AuthorizeClientCredentials())
                    {
                        authorizationState = AuthorizationState.AuthorizationInProgress;
                        //await Task.Delay(1000);
                    }
                }
                else
                    authorizationState = AuthorizationState.AuthorizationSucceeded;
                authorizationAttemptsCount++;
            } while (authorizationAttemptsCount<authorizationAttempts && authorizationState != AuthorizationState.AuthorizationSucceeded);
            return response;
        }
    }
}
