using Cobone.Models;
using Cobone.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Pages
{
    public partial class Login
    {
        AccountLogin model = new AccountLogin();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAccountDataService AccountDataService { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }
        private async void OnValidSubmit()
        {

            if (AccountDataService is not null)
            {
                if (await AccountDataService.Login(model))
                {
                    NavigationManager.NavigateTo("/", true);
                    StateHasChanged();
                }
                else
                {
                    Snackbar.Clear();
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomRight;
                    Snackbar.Add($"Failed to login: Invalid Email or Password", Severity.Error);
                }

            }
        }
    }
}
