using Cobone.Models;
using Cobone.Services;
using Microsoft.AspNetCore.Components;
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
        [Parameter] public string Id { get; set; }

        public FullProductInfo? Product { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ProductDataService is not null)
                Product = await ProductDataService.GetProductById(int.Parse(Id));
        }
    }
}
