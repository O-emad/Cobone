using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public class ShippingAddressDataService : IShippingAddressDataService
    {

        public ShippingAddressDataService(HttpClient httpClient)
        {
            HttpClient = httpClient??throw new ArgumentNullException(nameof(httpClient));
        }

        public HttpClient HttpClient { get; }

        public async Task AddShippingAddress(ShippingAddress address)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(address), Encoding.UTF8, "application/json");
                var response = await HttpClient.PostAsync("index.php?route=rest/shipping_address/shippingaddress", content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<ShippingAddress> GetShippingAddress()
        {
            var response = await JsonSerializer.DeserializeAsync<BaseResponse<ShippingAddress>>(await HttpClient.GetStreamAsync("index.php?route=rest/shipping_address/shippingaddress"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return response?.Data ?? new ShippingAddress();
        }

        public async Task SelectExistingShippingAddress(string shippingAddressId)
        {
            var content = new StringContent(JsonSerializer.Serialize(new { address_id = shippingAddressId }), encoding: Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync("index.php?route=rest/shipping_address/shippingaddress&existing=1", content);
            response?.EnsureSuccessStatusCode();
        }
    }
}
