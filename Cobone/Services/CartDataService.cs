using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Cobone.Services
{
    public class CartDataService : ICartDataService
    {
        private readonly HttpClient httpClient;

        public CartDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient??throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task AddToCart(CartItem item)
        {
            var content = new StringContent(JsonSerializer.Serialize(item),
                Encoding.UTF8,
                Application.Json);
            var response = await httpClient.PostAsync("index.php?route=rest/cart/cart", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCartItem(string key)
        {
            var response = await httpClient.DeleteAsync($"index.php?route=rest/cart/cart&key={key}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Cart> GetCartItems()
        {
            try
            {
                var response = await JsonSerializer.DeserializeAsync<BaseResponse<Cart>>(await httpClient.GetStreamAsync("index.php?route=rest/cart/cart"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return response?.Data ?? new Cart() { total_product_count = 0 };
            }
            catch
            {

            }
            return new Cart() { total_product_count = 0};
        }
    }
}
