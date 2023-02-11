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
    public partial class Registration
    {
        AccountRegister model = new AccountRegister();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAccountDataService AccountDataService { get; set; }
        [Inject]
        public IAccountAddressDataService AccountAddressDataService { get; set; }
        private async void OnValidSubmit()
        {

            if (AccountDataService is not null)
            {
                model.Custom_Field = new Custom_Field();
                model.Agree = 1;
                model.Customer_Group_Id = 1;
                await AccountDataService.Register(model);
                await AccountAddressDataService.AddAccountAddress(new AccountAddress
                {
                    firstname = "Demo",
                    lastname = "User",
                    company = "Demo Company name",
                    address_1 = "Demo",
                    address_2 = "Demo",
                    postcode = "3333",
                    city = "Berlin",
                    zone_code = "BER",
                    zone_id = "1256",
                    zone = "Berlin",
                    country_id = "81",
                    country = "Germany",
                    iso_code_2 = "DE",
                    iso_code_3 = "DEU",
                    address_format = "{company}\r\n{firstname} {lastname}\r\n{address_1}\r\n{address_2}\r\n{postcode} {city}\r\n{country}",
                    _default = false,
                    custom_field = new { }
                });
                NavigationManager.NavigateTo("/",true);
                StateHasChanged();

            }
        }
    }
}
