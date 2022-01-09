using Cobone.Services;
using Cobone.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.MessageHandlers
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
                string cookie = await cookieService.GetValue("Authorization", "Bearer db8da0586c299643d24aad2cc0ae3908ec39b21e");
                var cookieValues = cookie.Split(' ');
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(cookieValues[0],cookieValues[1]);
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
