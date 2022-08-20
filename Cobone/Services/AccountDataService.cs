using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public class AccountDataService : IAccountDataService
    {
        private readonly HttpClient httpClient;

        public AccountDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<AccountDetails> GetAccountDetails()
        {
            try
            {
                var response = await JsonSerializer.DeserializeAsync<BaseResponse<AccountDetails>>(
                    await httpClient.GetStreamAsync("index.php?route=rest/account/account"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return response?.Data ?? new AccountDetails();
            }catch (Exception ex)
            {
                return new AccountDetails();
            }
        }

        public async Task Login(AccountLogin accountLogin)
        {
            try
            {
                var loginJson =  new StringContent(JsonSerializer.Serialize(accountLogin).ToLower(), encoding: Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("index.php?route=rest/login/login", loginJson);
            }catch (Exception ex)
            {

            }
        }

        public async Task Logout()
        {
            try
            {
                var response = await httpClient.PostAsync("index.php?route=rest/logout/logout", null);
            }catch (Exception ex)
            {

            }
        }

        public async Task Register(AccountRegister accountRegister)
        {
            try
            {
                var registerJson = new StringContent(JsonSerializer.Serialize(accountRegister).ToLower(), encoding: Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("index.php?route=rest/register/register", registerJson);
            }catch (Exception ex)
            {

            }
        }
    }
}
