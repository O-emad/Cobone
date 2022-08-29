using Cobone;
using Cobone.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Microsoft.Extensions.DependencyInjection;
using Cobone.MessageHandlers;
using Cobone.Utils;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddSingleton<BrowserService>();
builder.Services.AddTransient<ICookie, Cookie>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddTransient<System.Security.Claims.ClaimsPrincipal>();
builder.Services.AddTransient<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>();

builder.Services.AddAuthorizationCore(authorizationOptions =>
{
    authorizationOptions.AddPolicy(
        Cobone.Policies.Policies.authorized,
         Cobone.Policies.Policies.CanAuthorize());
});
builder.Services.AddTransient<BaseMessageHandler>();
builder.Services.AddHttpClient<ICartDataService, CartDataService>("CartAPI", client => client.BaseAddress = new Uri("https://cobony-eg.com/controlcenter/index.php?route=rest/cart"))
    .AddHttpMessageHandler<BaseMessageHandler>();
builder.Services.AddHttpClient<ICategoryDataService, CategoryDataService>("CategoryAPI", client => client.BaseAddress = new Uri("https://cobony-eg.com/controlcenter/index.php?route=feed/rest_api/categories"))
    .AddHttpMessageHandler<BaseMessageHandler>();
builder.Services.AddHttpClient<IHomeDataService, HomeDataService>("HomeAPI", client => client.BaseAddress = new Uri("https://cobony-eg.com/controlcenter/index.php?route=feed/rest_api/getHome"))
    .AddHttpMessageHandler<BaseMessageHandler>();
builder.Services.AddHttpClient<IProductDataService, ProductDataService>("ProductAPI", client => client.BaseAddress = new Uri("https://cobony-eg.com/controlcenter/index.php?route=feed/rest_api/products"))
    .AddHttpMessageHandler<BaseMessageHandler>();
builder.Services.AddHttpClient<IAccountDataService, AccountDataService>("AccountAPI", client => client.BaseAddress = new Uri("https://cobony-eg.com/controlcenter/index.php?route=rest"))
    .AddHttpMessageHandler<BaseMessageHandler>();
builder.Services.AddHttpClient<IAuthorizationManager, AuthorizationManager>("AuthorizationAPI", client => client.BaseAddress = new Uri("https://cobony-eg.com/controlcenter/index.php?route=feed/rest_api/gettoken"));

await builder.Build().RunAsync();
