using CoboneMerchant.Models;
using CoboneMerchant.Services;
using CoboneMerchant.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Pages
{

    public partial class Index
    {
        [Inject]
        public ICategoryDataService? CategoryDataService { get; set; }
        [Inject]
        public IProductDataService ProductDataService { get; set; }
        [Inject]
        public IHomeDataService? HomeDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ICheckoutDataService CheckoutDataService { get; set; }
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        public Home? HomeData { get; set; }
        public List<CategoryProducts> CategoriesWithProducts { get; set; }
        public List<Category> Categories { get; set; }
        private bool _hasProducts = false;


        protected override async Task OnParametersSetAsync()
        {
            var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("ref", out var _ref))
            {
                var refQuery = Convert.ToString(_ref);
                if(refQuery == "confirm")
                {
                    if (CheckoutDataService is not null) await CheckoutDataService.ConfirmOrder();
                    NavigationManager.NavigateTo("/", true);
                }
            }
        }

        protected override void OnInitialized()
        {
            CategoriesWithProducts = new List<CategoryProducts>();
            Categories = new List<Category>();
            _hasProducts = false;
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (Layout.Categories is null) return;
            if (CategoryDataService is not null && Categories.Count == 0)
            {
                Categories = Layout.Categories;
                //Categories = (await CategoryDataService.GetCategories()).ToList();
            }

            if (ProductDataService is not null && CategoriesWithProducts.Count == 0)
            {
                foreach (var category in Categories)
                {
                    var products = await ProductDataService.GetProductsByCategoryId(category.Category_Id);
                    if (products != null && products.Count > 0)
                    {
                        CategoriesWithProducts.Add(new CategoryProducts
                        {
                            Category = category,
                            Products = products
                        });
                    }

                }
                StateHasChanged();
            }

       }

        private async void GetProductsThread()
        {
            while (Layout.Categories is null && !Layout.Categories!.Any())
            {
                Thread.Sleep(100);
            }
            Categories = Layout.Categories;
            if (ProductDataService is not null)
            {
                foreach (var category in Categories)
                {
                    var products = await ProductDataService.GetProductsByCategoryId(category.Category_Id);
                    if (products != null && products.Count > 0)
                    {
                        CategoriesWithProducts.Add(new CategoryProducts
                        {
                            Category = category,
                            Products = products
                        });
                    }

                }
                StateHasChanged();
            }
        }

        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public IAccountDataService AccountDataService { get; set; }
        private string authMessage;
        private string surnameMessage;
        private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();


        private async void Register()
        {
            if(AccountDataService is not null)
            {
                var register = new AccountRegister()
                {
                    Firstname = "Omar",
                    Lastname = "Rokiba",
                    Email = "o.emad@outlook.com",
                    Password = "123456789",
                    Confirm = "123456789",
                    Agree = 1,
                    Telephone = "01062164738",
                    Customer_Group_Id = 1,
                    Custom_Field = new Custom_Field()
                };
                await AccountDataService.Register(register);
            }
        }

        private async void Login()
        {
            if(AccountDataService is not null)
            {
                await AccountDataService.Login(new AccountLogin()
                {
                    Email = "o.emad@outlook.com",
                    Password = "123456789"
                });
            }
            StateHasChanged();
            NavigationManager.NavigateTo("/", true);
            
        }

        private async void Logout()
        {
            if(AccountDataService is not null)
            {
                await AccountDataService.Logout();
            }
            StateHasChanged();
        }
        private async Task GetClaimsPrincipalData()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                authMessage = $"{user.Identity.Name} is authenticated.";
                claims = user.Claims;
                surnameMessage =
                    $"Surname: {user.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value}";
            }
            else
            {
                authMessage = "The user is NOT authenticated.";
            }
        }

    }
}
