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

        public async Task<bool> Login(AccountLogin accountLogin)
        {
            try
            {
                var loginJson =  new StringContent(JsonSerializer.Serialize(accountLogin).ToLower(), encoding: Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("index.php?route=rest/login/login", loginJson);
                response.EnsureSuccessStatusCode();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
        public async Task ForgotPassword(AccountForgotPassword accountForgotPassword)
        {
            try
            {
                var forgotCredentialsJson = new StringContent(JsonSerializer.Serialize(accountForgotPassword).ToLower(), encoding: Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("index.php?route=rest/forgotten/forgotten", forgotCredentialsJson);
            }
            catch (Exception ex)
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

        public async Task ChangePassword(AccountPasswordChange passwordChange)
        {
            try
            {
                var passwordChangeJson = new StringContent(JsonSerializer.Serialize(passwordChange).ToLower(), encoding: Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("index.php?route=rest/account/password", passwordChangeJson);
                response.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateAccountDetails(AccountUpdateDetails accountUpdate)
        {
            try
            {
                var accountUpdateJson = new StringContent(JsonSerializer.Serialize(accountUpdate).ToLower(), encoding: Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("index.php?route=rest/account/account", accountUpdateJson);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
