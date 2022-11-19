using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public class MerchantDataService : IMerchantDataService
    {
        private readonly HttpClient httpClient;

        public MerchantDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<AccountOrderDetails> GetOrderById(int id)
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
    }
}
