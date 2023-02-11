using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public class ProductDataService : IProductDataService
    {
        private readonly HttpClient httpClient;

        public ProductDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient??throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<FullProductInfo> GetProductById(int id)
        {
            var response = await JsonSerializer.DeserializeAsync<BaseResponse<FullProductInfo>>(await httpClient.GetStreamAsync($"index.php?route=feed/rest_api/products&id={id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response?.Data ?? new FullProductInfo();
        }

        public async Task<List<ProductSearch>> GetProductByName(string name)
        {
            var response = await JsonSerializer.DeserializeAsync<BaseResponse<List<ProductSearch>>>
                (await httpClient.GetStreamAsync($"index.php?route=feed/rest_api/products&custom_fields=id,name&search={name}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response?.Data ?? new List<ProductSearch>();
        }

        public async Task<List<Product>> GetProductsByCategoryId(int id)
        {

            var response = await JsonSerializer.DeserializeAsync<BaseResponse<List<Product>>>(await httpClient.GetStreamAsync($"index.php?route=feed/rest_api/products&category={id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
            return response?.Data ?? new List<Product>();
        }
    }
}
