using CoboneMerchant.Models;
using CoboneMerchant.Services;
using CoboneMerchant.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Pages
{
    public partial class CategoryDeal
    {
        [ParameterAttribute]
        public string? CategoryId { get; set; }


        [Inject]
        public IProductDataService? ProductDataService { get; set; }

        public List<Product> Products { get; set; }
        public int RenderedCategoryId { get; set; } = -1;
        [CascadingParameter]
        public MainLayout Layout { get; set; }
        public string CategoryName { get; set; }

        protected override void OnInitialized()
        {
            Products = new List<Product>();

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (Layout.Categories is null) return;
            if (!string.IsNullOrWhiteSpace(CategoryId))
            {
                var idParsed = int.TryParse(CategoryId, out var id);
                if (id != RenderedCategoryId)
                {
                    RenderedCategoryId = id;
                    var category = Layout.Categories.Where(c => c.Category_Id == id || (c.Categories?.Any(sc => sc.Category_Id == id) ?? false)).FirstOrDefault();
                    if(category is not null)
                    {
                        if (category.Category_Id == id)
                            CategoryName = category.Name ?? "";
                        else
                            CategoryName = category.Categories?.Where(c => c.Category_Id == id).FirstOrDefault()?.Name??"";
                    }
                }
                else
                    return;
                if (ProductDataService is not null && idParsed)
                {
                    Products = await ProductDataService.GetProductsByCategoryId(id);
                    StateHasChanged();
                }
                else
                {
                    throw new ArgumentNullException(nameof(ProductDataService), "either productdataservice is null or the categoryId couldn't be parsed to int");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(CategoryId), "categoryId is either null of whitespace");
            }
            
            await base.OnAfterRenderAsync(firstRender);
        }

    }
}
