using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;

namespace Cobone.Utils
{
    public static class WebAssemblyHostExtension
    {
        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            var localStorage = host.Services.GetRequiredService<ILocalStorageService>();
            //var cookieService = host.Services.GetRequiredService<ICookie>();
            var cultureFromLS = await localStorage.GetItemAsync<string>("culture");

            CultureInfo culture;

            if (cultureFromLS != null)
            {
                culture = new CultureInfo(cultureFromLS);
            }
            else
            {
                culture = new CultureInfo("en-US");
            }

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            //cookieService.SetValue("language", culture.DisplayName);
        }
    }
}