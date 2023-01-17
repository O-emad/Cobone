using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient httpClient;

        public CountryDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var response = await JsonSerializer.DeserializeAsync<BaseResponse<List<Country>>>(await httpClient.GetStreamAsync("index.php?route=feed/rest_api/countries"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return response?.Data ?? new List<Country>();
        }
    }
}
