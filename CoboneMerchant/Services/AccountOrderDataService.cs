using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public class AccountOrderDataService : IAccountOrderDataService
    {
        private readonly HttpClient httpClient;

        public AccountOrderDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient??throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<AccountOrderDetails> GetAccountOrderDetails(int id)
        {
            try
            {
                var response = await JsonSerializer.DeserializeAsync<BaseResponse<AccountOrderDetails>>(
                    await httpClient.GetStreamAsync($"index.php?route=rest/order/orders&id={id}"),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );
                return response?.Data ?? new AccountOrderDetails();
            }
            catch (Exception ex)
            {

                return new AccountOrderDetails();
            }
        }

        public async Task<List<AccountOrder>> GetAccountOrders(int page, int pageSize)
        {
            try
            {
                var response = await JsonSerializer.DeserializeAsync<BaseResponse<List<AccountOrder>>>(
                    await httpClient.GetStreamAsync($"index.php?route=rest/order/orders&limit={pageSize}&page={page}"),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );
                return response?.Data ?? new List<AccountOrder>();
            }
            catch (Exception ex)
            {

                return new List<AccountOrder>();
            }
        }
    }
    ///index.php?route=rest/order/orders&limit={limit}&page={page}
}
