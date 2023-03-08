using CoboneMerchant.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Shared
{
    public partial class MainLayout
    {

        public static readonly MudTheme MyCustomTheme = new MudTheme()
        {
            Palette = new Palette()
            {

                Success = Colors.LightGreen.Accent4,
                Primary = "#59b210",
                Secondary = "#fafafa",
                AppbarBackground = "#59b210",
                Tertiary = "#ffffff",
                Dark = Colors.Grey.Lighten1

            },

            LayoutProperties = new LayoutProperties()
            {
                DrawerWidthLeft = "260px",
                DrawerWidthRight = "300px"
            }
        };

        private async void Logout()
        {
            if (AccountDataService is not null)
            {
                await AccountDataService.Logout();
            }
            StateHasChanged();
            NavigationManager.NavigateTo("/merchant", true);
        }

    }
}
