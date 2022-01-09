using Cobone.Models;
using Cobone.Services;
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
        public IHomeDataService? HomeDataService { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public Home HomeData { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if(CategoryDataService is not null)
                Categories = await CategoryDataService.GetCategories();
            if (HomeDataService is not null)
                HomeData = await HomeDataService.GetHomeData();

        }
    }
}
