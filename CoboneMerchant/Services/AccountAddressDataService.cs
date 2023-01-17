using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public class AccountAddressDataService : IAccountAddressDataService
    {
        private readonly HttpClient httpClient;

        public AccountAddressDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task AddAccountAddress(AccountAddress accountAddress)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(accountAddress), Encoding.UTF8, "application/json");
                var resposne = await httpClient.PostAsync("index.php?route=rest/account/address", content);
                resposne.EnsureSuccessStatusCode();
            }catch(Exception ex)
            {

            }
        }

        public async Task<IEnumerable<AccountAddress>> GetAccountAddresses()
        {
            var response = await JsonSerializer.DeserializeAsync<BaseResponse<AccountAddressResposne>>(await httpClient.GetStreamAsync("index.php?route=rest/account/address"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response?.Data?.Addresses ?? new List<AccountAddress>();

        }

        public async Task RemoveAccountAddress(string id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"index.php?route=rest/account/address?id={id}");
                response?.EnsureSuccessStatusCode();
            }
            catch(Exception ex) { }
        }
    }
}
