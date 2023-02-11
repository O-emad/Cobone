using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public class RelatedProductsDataService : IRelatedProductsDataService
    {
        private readonly HttpClient httpClient;

        public RelatedProductsDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<RelatedProducts>> GetRelatedProducts(string id)
        {
            var response = await JsonSerializer.DeserializeAsync<BaseResponse<List<RelatedProducts>>>(await httpClient.GetStreamAsync($"index.php?route=feed/rest_api/related&id={id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response?.Data ?? new List<RelatedProducts>();
        }
    }
}
