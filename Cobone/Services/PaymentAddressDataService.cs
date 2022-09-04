using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public class PaymentAddressDataService:IPaymentAddressDataService
    {
        public PaymentAddressDataService(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public HttpClient HttpClient { get; }

        public async Task AddPaymentAddress(PaymentAddress address)
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

        public async Task<PaymentAddress> GetPaymentAddress()
        {
            var response = await JsonSerializer.DeserializeAsync<BaseResponse<PaymentAddress>>(await HttpClient.GetStreamAsync("index.php?route=rest/shipping_address/shippingaddress"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return response?.Data ?? new PaymentAddress();
        }

        public async Task SelectExistingPaymentAddress(string paymentAddressId)
        {
            var content = new StringContent(JsonSerializer.Serialize(new { address_id = paymentAddressId }), encoding: Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync("index.php?route=rest/payment_address/paymentaddress&existing=1", content);
            response?.EnsureSuccessStatusCode();
        }
    }
}
