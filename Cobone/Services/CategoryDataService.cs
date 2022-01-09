using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public class CategoryDataService : ICategoryDataService
    {
        private readonly HttpClient httpClient;

        public CategoryDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient??throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {            
            var response  =  await JsonSerializer.DeserializeAsync<BaseResponse<List<Category>>>(await httpClient.GetStreamAsync(""),new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response?.Data ?? Enumerable.Empty<Category>(); 
        }

        public Task<IEnumerable<Category>> GetCategoriesByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategoriesToDepth(int depth)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
