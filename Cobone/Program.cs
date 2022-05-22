using Cobone;
using Cobone.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Microsoft.Extensions.DependencyInjection;
using Cobone.MessageHandlers;
using Cobone.Utils;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddSingleton<BrowserService>();
builder.Services.AddTransient<ICookie, Cookie>();
builder.Services.AddTransient<BaseMessageHandler>();
builder.Services.AddHttpClient<ICategoryDataService, CategoryDataService>("CategoryAPI", client => client.BaseAddress = new Uri("https://rokiba.com/demo/store/index.php?route=feed/rest_api/categories"))
    .AddHttpMessageHandler<BaseMessageHandler>();
builder.Services.AddHttpClient<IHomeDataService, HomeDataService>("HomeAPI", client => client.BaseAddress = new Uri("https://rokiba.com/demo/store/index.php?route=feed/rest_api/getHome"))
    .AddHttpMessageHandler<BaseMessageHandler>();
builder.Services.AddHttpClient<IProductDataService, ProductDataService>("ProductAPI", client => client.BaseAddress = new Uri("https://rokiba.com/demo/store/index.php?route=feed/rest_api/products"))
    .AddHttpMessageHandler<BaseMessageHandler>();
builder.Services.AddHttpClient<IAuthorizationManager, AuthorizationManager>("AuthorizationAPI", client => client.BaseAddress = new Uri("https://rokiba.com/demo/store/index.php?route=feed/rest_api/gettoken"));
await builder.Build().RunAsync();
