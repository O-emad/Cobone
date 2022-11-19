using Cobone.Components;
using Cobone.Models;
using Cobone.Services;
using Cobone.Shared;
using Microsoft.AspNetCore.Components;
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
        public IProductDataService? ProductDataService { get; set; }
        [Inject]
        public ICartDataService? CartDataService { get; set; }
        [Inject] 
        public ISnackbar Snackbar { get; set;}
        [Parameter] public string Id { get; set; }

        public FullProductInfo? Product { get; set; }

        public Dictionary<int, int> SelectedOptions { get; set; } = new Dictionary<int, int>();
        public int SelectedQuantity { get; set; }
        [CascadingParameter]
        public MainLayout Layout { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ProductDataService is not null)
                Product = await ProductDataService.GetProductById(int.Parse(Id));
        }

        private async Task AddToCart()
        {
            if (SelectedOptions.Count > 0)
            {
                foreach (var option in SelectedOptions)
                {
                    var selectedOption = Product.options.FirstOrDefault();
                    var cartItem = new CartItem()
                    {
                        product_id = Product.Product_Id.ToString(),
                        quantity = option.Value.ToString(),
                        option = new Dictionary<string, string>() { { selectedOption?.product_option_id.ToString() ?? " ", option.Key.ToString() ?? " " } }
                    };
                    var quantityOfCartItemInCart = int.Parse(Layout.Cart.products?.Where(p => p.product_id == cartItem.product_id)
                        .FirstOrDefault(new CartProduct() { quantity = "0" }).quantity ?? "0");
                    var quantityOfNewRequestedCartItem = SelectedQuantity;
                    var canAddToCart = selectedOption.option_value.Where(o=>o.product_option_value_id == option.Key).FirstOrDefault()
                        .quantity >= quantityOfCartItemInCart + quantityOfNewRequestedCartItem;
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
    }
}
