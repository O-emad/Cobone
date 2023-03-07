using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public class OrderStatusDataService : IOrderStatusDataService
    {
        private readonly HttpClient httpClient;

        public OrderStatusDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public Task<List<OrderStatus>> GetOrderStatuses()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RedeemOfferOnOrder(string id)
        {
            try
            {
                var content = new StringContent("{\r\n  \"order_status_id\": 5,\r\n  \"notify\": 0,\r\n  \"comment\": \"This offer has been redeemed\"\r\n}", Encoding.UTF8,"application/json");
                var response = await httpClient.PutAsync($"index.php?route=feed/rest_api/orderhistory&id={id}", content);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
