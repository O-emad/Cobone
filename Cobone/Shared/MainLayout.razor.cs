﻿using Cobone.Models;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Shared
{
    public partial class MainLayout :IAsyncDisposable
    {
        public List<Category> Categories { get; set; }
        public Home? HomeData { get; set; }
        private BreadcrumbItem item;
        private MudButton button;
        public int ShoppingCartContent { get; set; } = 0;
        private Guid _subscriptionId;
        private Breakpoint breakPoint;
        private bool openDrawer = false;

        private void MoveToIndex()
        {
            NavigationManager.NavigateTo("/");
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var subscriptionResult = await BreakpointListener.Subscribe(async (breakpoint) =>
                {
                    breakPoint = breakpoint;
                    await InvokeAsync(StateHasChanged);
                }, new ResizeOptions
                {
                    ReportRate = 50,
                    NotifyOnBreakpointOnly = true,
                });

                breakPoint = subscriptionResult.Breakpoint;
                _subscriptionId = subscriptionResult.SubscriptionId;
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    protected override async Task OnInitializedAsync()
        {
            if (CategoryDataService is not null)
            {
                Categories = (await CategoryDataService.GetCategories()).ToList();
            }
            if (HomeDataService is not null)
            {
                HomeData = await HomeDataService.GetHomeData();
            }
        }

        private async void Logout()
        {
            if (AccountDataService is not null)
            {
                await AccountDataService.Logout();
            }
            StateHasChanged();
            NavigationManager.NavigateTo("/", true);
        }

        public static readonly MudTheme MyCustomTheme = new MudTheme()
        {
            Palette = new Palette()
            {

                Success = Colors.LightGreen.Accent4,
                Primary = "#59b210",
                Secondary = "#fafafa",
                AppbarBackground = "#59b210",
                Tertiary = "#ffffff",
               
            },

            LayoutProperties = new LayoutProperties()
            {
                DrawerWidthLeft = "260px",
                DrawerWidthRight = "300px"
            }
        };

        private void GoToLogin()
        {
            NavigationManager.NavigateTo("/login");

        }

        void ToggleDrawer()
        {
            openDrawer = !openDrawer;
        }



        public async ValueTask DisposeAsync() => await BreakpointListener.Unsubscribe(_subscriptionId);
    }
}