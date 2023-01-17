using CoboneMerchant.Models;
using CoboneMerchant.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Pages
{
    public partial class Login
    {
        AccountLogin model = new AccountLogin();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAccountDataService AccountDataService { get; set; }
        private async void OnValidSubmit()
        {

            if (AccountDataService is not null)
            {
                await AccountDataService.Login(model);
                NavigationManager.NavigateTo("/", true);
                StateHasChanged();

            }
        }
    }
}
