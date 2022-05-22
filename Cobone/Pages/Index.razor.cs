using Cobone.Models;
using Cobone.Services;
using Cobone.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Pages
{

    public partial class Index
    {
        [Inject]
        public ICategoryDataService? CategoryDataService { get; set; }
        [Inject]
        public IProductDataService ProductDataService { get; set; }
        [Inject]
        public IHomeDataService? HomeDataService { get; set; }
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        public Home? HomeData { get; set; }
        public List<CategoryProducts> CategoriesWithProducts { get; set; }
        public List<Category> Categories { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                CategoriesWithProducts = new List<CategoryProducts>();
                Categories = new List<Category>();
                if (CategoryDataService is not null)
                {
                    Categories = (await CategoryDataService.GetCategories()).ToList();
                }
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
        }
    }
}
