using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cobone.Services
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

        public async Task<Tuple<int, List<AccountOrder>>> GetAccountOrders(int page, int pageSize)
        {
            try
            {
                var res = await httpClient.GetAsync($"index.php?route=rest/order/orders&limit={pageSize}&page={page}");
                var response = await JsonSerializer.DeserializeAsync<BaseResponse<List<AccountOrder>>>(
                    res.Content.ReadAsStream(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );
                var hasCountHeader = int.TryParse(res.Headers.FirstOrDefault(h => string.Equals(h.Key, "x-total-count", StringComparison.OrdinalIgnoreCase)).Value?.FirstOrDefault(), out int totalCount);
                return new Tuple<int, List<AccountOrder>>(hasCountHeader?totalCount:100, response?.Data ?? new List<AccountOrder>());
            }
            catch (Exception ex)
            {

                return new Tuple<int, List<AccountOrder>>(0,new());
            }
        }
    }
    ///index.php?route=rest/order/orders&limit={limit}&page={page}
}
