using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static MudBlazor.CategoryTypes;
using static System.Net.Mime.MediaTypeNames;

namespace Cobone.Services
{
    public class ContactUsDataService : IContactUsDataService
    {
        private readonly HttpClient httpClient;

        public ContactUsDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task SendMessage(ContactUsModel model)
        {
            var content = new StringContent(JsonSerializer.Serialize(model),
                Encoding.UTF8,
                Application.Json);
            var response = await httpClient.PostAsync("index.php?route=rest/contact/send", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
