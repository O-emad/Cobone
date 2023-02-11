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
    public partial class Registration
    {
        AccountRegister model = new AccountRegister();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAccountDataService AccountDataService { get; set; }
        private async void OnValidSubmit()
        {

            if (AccountDataService is not null)
            {
                model.Custom_Field = new Custom_Field();
                model.Agree = 1;
                model.Customer_Group_Id = 1;
                await AccountDataService.Register(model);
                NavigationManager.NavigateTo("",true);
                StateHasChanged();

            }
        }
    }
}
