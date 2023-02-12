using Cobone.Components;
using Cobone.Models;
using Cobone.Services;
using Cobone.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Pages
{
    public partial class ProductInfo
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IProductDataService? ProductDataService { get; set; }
        [Inject]
        public IRelatedProductsDataService? RelatedProductsDataService { get; set; }
        [Inject]
        public ICartDataService? CartDataService { get; set; }
        [Inject] 
        public ISnackbar Snackbar { get; set;}
        [Parameter] public string Id { get; set; }

        public FullProductInfo? Product { get; set; }
        public List<RelatedProducts> RelatedProducts { get; set; } = new List<RelatedProducts>();

        public Dictionary<int, int> SelectedOptions { get; set; } = new Dictionary<int, int>();
        public int SelectedQuantity { get; set; }
        [CascadingParameter]
        public MainLayout Layout { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ProductDataService is not null)
                Product = await ProductDataService.GetProductById(int.Parse(Id));
            if (RelatedProductsDataService is not null)
                RelatedProducts = await RelatedProductsDataService.GetRelatedProducts(Id);

        }

        private async Task AddToCart()
        {
            if (SelectedOptions.Count > 0)
            {
                foreach (var option in SelectedOptions)
                {
                    var productData = new {id =0, quantity=0 };

                    if (option.Key == Product.Product_Id)
                    {
                        productData = new
                        {
                            id = Product.Product_Id,
                            quantity = Product.Quantity
                        };

                    }
                    else
                    {
                        var selectedOption = RelatedProducts.FirstOrDefault(rp => rp.product_id == option.Key);
                        if (selectedOption is null) continue;
                        productData = new
                        {
                            id = selectedOption.product_id,
                            quantity = selectedOption.quantity
                        };
                    }
                    var cartItem = new CartItem()
                    {
                        product_id = productData.id.ToString(),
                        quantity = option.Value.ToString(),
                        option = new Dictionary<string, string>() { { " ",  " " } }
                    };
                    var quantityOfCartItemInCart = int.Parse(Layout.Cart.products?.Where(p => p.product_id == cartItem.product_id)
                        .FirstOrDefault(new CartProduct() { quantity = "0" }).quantity ?? "0");
                    var quantityOfNewRequestedCartItem = SelectedQuantity;
                    var canAddToCart = productData.quantity >= quantityOfCartItemInCart + quantityOfNewRequestedCartItem;
                    if (!canAddToCart)
                    {
                        Snackbar.Add("Requested Quantity Exceeds Available Quanity", Severity.Error);
                        continue;
                    }
                    if (CartDataService is not null)
                    {
                        await CartDataService.AddToCart(cartItem);
                    }
                }
                await Layout.RefreshCart();
                Layout.OpenCartPopOver();
            }
        }
        private async Task QuickCheckout()
        {
            if (SelectedOptions.Count > 0)
            {
                foreach (var option in SelectedOptions)
                {
                    var productData = new { id = 0, quantity = 0 };

                    if (option.Key == Product.Product_Id)
                    {
                        productData = new
                        {
                            id = Product.Product_Id,
                            quantity = Product.Quantity
                        };

                    }
                    else
                    {
                        var selectedOption = RelatedProducts.FirstOrDefault(rp => rp.product_id == option.Key);
                        if (selectedOption is null) continue;
                        productData = new
                        {
                            id = selectedOption.product_id,
                            quantity = selectedOption.quantity
                        };
                    }
                    var cartItem = new CartItem()
                    {
                        product_id = productData.id.ToString(),
                        quantity = option.Value.ToString(),
                        option = new Dictionary<string, string>() { { " ", " " } }
                    };
                    var quantityOfCartItemInCart = int.Parse(Layout.Cart.products?.Where(p => p.product_id == cartItem.product_id)
                        .FirstOrDefault(new CartProduct() { quantity = "0" }).quantity ?? "0");
                    var quantityOfNewRequestedCartItem = SelectedQuantity;
                    var canAddToCart = productData.quantity >= quantityOfCartItemInCart + quantityOfNewRequestedCartItem;
                    if (!canAddToCart)
                    {
                        Snackbar.Add("Requested Quantity Exceeds Available Quanity", Severity.Error);
                        continue;
                    }
                    if (CartDataService is not null)
                    {
                        await CartDataService.AddToCart(cartItem);
                    }
                }
                await Layout.RefreshCart();
                var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;
                if (user.Identity?.IsAuthenticated ?? false)
                {
                    NavigationManager.NavigateTo("/checkout");
                    Layout.CloseOverlay();
                }
                else
                {
                    NavigationManager.NavigateTo("/login");
                    Layout.CloseOverlay();
                }
                //Layout.OpenCartPopOver();

            }
        }
    }
}
