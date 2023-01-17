using CoboneMerchant;
using CoboneMerchant.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Microsoft.Extensions.DependencyInjection;
using CoboneMerchant.MessageHandlers;
using CoboneMerchant.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Syncfusion.Blazor;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddLocalization();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 2000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddSingleton<BrowserService>();
builder.Services.AddTransient<ICookie, Cookie>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddTransient<System.Security.Claims.ClaimsPrincipal>();
builder.Services.AddTransient<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>();

builder.Services.AddAuthorizationCore(authorizationOptions =>
{
    authorizationOptions.AddPolicy(
        CoboneMerchant.Policies.Policies.authorized,
         CoboneMerchant.Policies.Policies.CanAuthorize());
});
builder.Services.AddTransient<BaseMessageHandler>();
builder.Services.AddHttpClient<IAccountDataService, AccountDataService>("AccountAPI", client => client.BaseAddress = new Uri("https://cobony-eg.com/controlcenter/index.php?route=rest"))
    .AddHttpMessageHandler<BaseMessageHandler>();
builder.Services.AddHttpClient<IMerchantDataService, MerchantDataService>("MerchantAPI", client => client.BaseAddress = new Uri("https://cobony-eg.com/controlcenter/index.php?route=rest/order"))
    .AddHttpMessageHandler<BaseMessageHandler>();

builder.Services.AddHttpClient<IAuthorizationManager, AuthorizationManager>("AuthorizationAPI", client => client.BaseAddress = new Uri("https://cobony-eg.com/controlcenter/index.php?route=feed/rest_api/gettoken"));


builder.Services.AddSyncfusionBlazor();
var host = builder.Build();

await host.SetDefaultCulture();

await host.RunAsync();

