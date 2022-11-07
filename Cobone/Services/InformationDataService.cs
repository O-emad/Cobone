using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public class InformationDataService : IInformationDataService
    {

        public InformationDataService(HttpClient httpClient)
        {
            HttpClient = httpClient?? throw new ArgumentNullException(nameof(httpClient));
        }

        public HttpClient HttpClient { get; }

        public async Task<InformationDetails> GetInformationDetails(int id)
        {
            var response = await JsonSerializer.DeserializeAsync<BaseResponse<InformationDetails>>(await HttpClient.GetStreamAsync($"index.php?route=feed/rest_api/information&id={id}")
                , new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response?.Data ?? new InformationDetails();
        }

        public async Task<List<Information>> GetSiteInformation()
        {
            var response = await JsonSerializer.DeserializeAsync<BaseResponse<List<Information>>>(await HttpClient.GetStreamAsync("index.php?route=feed/rest_api/information"),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return response?.Data ?? new List<Information>();
        }
    }
}
