using Cobone.Models;
using Cobone.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cobone.Shared
{
    public partial class MainLayout :IAsyncDisposable
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public IProductDataService ProductDataService { get; set; }
        public List<Category> Categories { get; set; }
        public Home? HomeData { get; set; }
        private BreadcrumbItem item;
        private MudButton button;
        public int ShoppingCartContent { get; set; } = 0;
        private Guid _subscriptionId;
        private Breakpoint breakPoint;
        private bool openDrawer = false;
        public Cart Cart { get; set; } = new Cart()
        {
            total_product_count = 0
        };

        public bool CartPopoverOpen { get; set; } = false;
        public bool SpecialPopoverOpen { get; set; } = false;

        public bool OverlayOpen { get; set; } = false;
        public string Search { get; set; }
        public string LanguageLabel { get; set; } = "English";
        public bool _RTL { get; set; } = false;
        public List<string> Languages { get; set; } = new List<string>() { "English", "العربيه" };
        public List<Information> Infos { get; set; } = new List<Information>();




        private async Task<IEnumerable<string>> Search1(string value)
        {
            if (ProductDataService is not null)
            {
                if (string.IsNullOrEmpty(value))
                    return HomeData.BestSeller.Select(p => p.Name).Distinct().ToList();
                var values = await ProductDataService.GetProductByName(value);
                if (values is not null && values.Count > 0) return values.Select(p=>p.name).Distinct();
            }
            return new List<string>() { "Couldn't be found" };
        }

        public void OpenCartPopOver()
        {
            CartPopoverOpen = true;
            SpecialPopoverOpen = false;
            OverlayOpen = true;
            StateHasChanged();
        }

        private void OpenSpecialPopOver()
        {
            SpecialPopoverOpen = true; ;
            CartPopoverOpen = false;
            OverlayOpen = true;
        }

        public void CloseOverlay()
        {
            CartPopoverOpen = false;
            SpecialPopoverOpen = false;
            OverlayOpen = false;
        }

        private void NavigateToMerchant()
        {
            NavigationManager.NavigateTo("/merchant");
        }

        private void MoveToIndex()
        {
            NavigationManager.NavigateTo("/");
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var subscriptionResult = await BreakpointListener.Subscribe(async (breakpoint) =>
                {
                    breakPoint = breakpoint;
                    await InvokeAsync(StateHasChanged);
                }, new ResizeOptions
                {
                    ReportRate = 50,
                    NotifyOnBreakpointOnly = true,
                });

                breakPoint = subscriptionResult.Breakpoint;
                _subscriptionId = subscriptionResult.SubscriptionId;
                StateHasChanged();
            }
            //await RefreshCart();
            await base.OnAfterRenderAsync(firstRender);
        }
    protected override async Task OnInitializedAsync()
        {
            if (CategoryDataService is not null)
            {
                Categories = (await CategoryDataService.GetCategories()).ToList();
            }
            if (HomeDataService is not null)
            {
                HomeData = await HomeDataService.GetHomeData();
            }
            if (CartDataService is not null){
                Cart = await CartDataService.GetCartItems();
            }
            if(InformationDataService is not null)
            {
                Infos = await InformationDataService.GetSiteInformation();
            }
        }

        public async Task RefreshCart()
        {
            if (CartDataService is not null)
            {
                Cart = await CartDataService.GetCartItems();
                StateHasChanged();
                
            }
        }


        public async Task Checkout()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity?.IsAuthenticated ?? false)
            {
                NavigationManager.NavigateTo("/checkout");
                CloseOverlay();
            }
            else
            {
                NavigationManager.NavigateTo("/login");
                CloseOverlay();
            }
        }


        private async void Logout()
        {
            if (AccountDataService is not null)
            {
                await AccountDataService.Logout();
            }
            StateHasChanged();
            NavigationManager.NavigateTo("/", true);
        }

        public static readonly MudTheme MyCustomTheme = new MudTheme()
        {
            Palette = new Palette()
            {

                Success = Colors.LightGreen.Accent4,
                Primary = "#59b210",
                Secondary = "#F5F5F5",
                AppbarBackground = "#59b210",
                Tertiary = "#ffffff",
                Dark = Colors.Grey.Lighten1,
                Info = Colors.Shades.Black
                

            },

            LayoutProperties = new LayoutProperties()
            {
                DrawerWidthLeft = "260px",
                DrawerWidthRight = "300px"
                
            },
            
        };

        private void GoToLogin()
        {
            NavigationManager.NavigateTo("/login");

        }

        void ToggleDrawer()
        {
            openDrawer = !openDrawer;
        }

        private void OnLanguageMenuItemClick(string language)
        {
            LanguageLabel = language;
            _RTL = !(language == "English");
        }

        public async ValueTask DisposeAsync() => await BreakpointListener.Unsubscribe(_subscriptionId);
    }
}
