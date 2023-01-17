using CoboneMerchant.Models;
using CoboneMerchant.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Pages
{
    public partial class Index
    {
        [Inject]
        public IMerchantDataService MerchantDataService { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }
        private int orderId ;

        private bool searched = false;
        private AccountOrderDetails SearchedOrderDetails { get; set; }

        public async Task Search()
        {
            if (MerchantDataService is not null)
            {
                SearchedOrderDetails = await MerchantDataService.GetOrderById(orderId);
                if (!string.IsNullOrWhiteSpace(SearchedOrderDetails.order_id))
                {
                    searched = true;
                }
                else
                {
                    Snackbar.Clear();
                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomRight;
                    Snackbar.Add($"No Order available with id = {orderId}", Severity.Error);
                    searched = false;
                }
            }
        }
    }
}
