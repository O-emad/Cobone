using Cobone.Models;
using Cobone.Utils;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly HttpClient httpClient;
        private readonly ICookie cookieService;

        public AuthorizationManager(HttpClient httpClient, ICookie cookieService)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.cookieService = cookieService ?? throw new ArgumentNullException(nameof(cookieService));
        }

        //TODO: Inject Client Credential Service to gain access to the old access token
        public async Task<bool> AuthorizeClientCredentials()
        {
            
            var request = new HttpRequestMessage(HttpMethod.Post, "/demo/store/index.php?route=feed/rest_api/gettoken&grant_type=client_credentials");
            //request.SetBrowserRequestMode(BrowserRequestMode.NoCors);
            request.Headers.Add("Authorization", "Basic cm9raWJhX29hdXRoX2NsaWVudDpyb2tpYmFfb2F1dGhfc2VjcmV0");
            
            request.Content = new StringContent("{\"old_token\": \"db8da0586c299643d24aad2cc0ae3908ec39b21e\"}", Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var deserializedResponse = await JsonSerializer.DeserializeAsync<BaseResponse<Authorize>>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                if (deserializedResponse is null || deserializedResponse.Data is null) return false;
                var token = deserializedResponse.Data.Access_Token;
                var tokenType = deserializedResponse.Data.Token_Type;
                await cookieService.SetValue("Authorization", $"{tokenType} {token}", 1);
                return true;
            }
            return false; 
        }
    }
}
