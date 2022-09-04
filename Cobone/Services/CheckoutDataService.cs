using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public class CheckoutDataService : ICheckoutDataService
    {
        private readonly HttpClient httpClient;

        public CheckoutDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient??throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task ConfirmOrder()
        {
            var response = await httpClient.PutAsync("index.php?route=rest/confirm/confirm", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<OrderOverview> GetOrderOverview()
        {
            var response = await httpClient.PostAsync("index.php?route=rest/confirm/confirm", null);
            response.EnsureSuccessStatusCode();
            return new OrderOverview();
        }

        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethods()
        {
            var resposne = await JsonSerializer.DeserializeAsync<BaseResponse<PaymentMethodResponse>>(await httpClient.GetStreamAsync("index.php?route=rest/payment_method/payments "),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return resposne?.Data?.payment_methods ?? Enumerable.Empty<PaymentMethod>();
        }

        public async Task<IEnumerable<ShippingMethod>> GetShippingMethods()
        {
            var response = await JsonSerializer.DeserializeAsync<BaseResponse<ShippingMethodResponse>>(await httpClient.GetStreamAsync("index.php?route=rest/shipping_method/shippingmethods"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return response?.Data?.shipping_methods ?? Enumerable.Empty<ShippingMethod>();
        }

        public async Task SelectPaymentMethod(string paymentMethod)
        {
            var content = new StringContent(JsonSerializer.Serialize(new { payment_method = paymentMethod, agree = 1, comment = "none" }), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("index.php?route=rest/payment_method/payments", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task SelectShippingMethod(string methodCode)
        {
            var content = new StringContent(JsonSerializer.Serialize(new { shipping_method = methodCode, comment = "none" }), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("index.php?route=rest/shipping_method/shippingmethods", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
