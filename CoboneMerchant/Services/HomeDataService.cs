using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public class HomeDataService : IHomeDataService
    {
        public HttpClient HttpClient { get; }

        public HomeDataService(HttpClient httpClient)
        {
            HttpClient = httpClient?? throw new ArgumentNullException(nameof(httpClient));
        }



        public async Task<Home> GetHomeData()
        {
            var response = await JsonSerializer.DeserializeAsync<BaseResponse<Home>>(await HttpClient.GetStreamAsync(""), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response?.Data ?? new Home();
        }


    }
}
