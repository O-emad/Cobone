using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public interface ICheckoutDataService
    {
        Task<IEnumerable<PaymentMethod>> GetPaymentMethods();
        Task SelectPaymentMethod(string paymentMethod);
        Task<IEnumerable<ShippingMethod>> GetShippingMethods();
        Task SelectShippingMethod(string methodCode);
        Task<OrderOverview> GetOrderOverview();
        Task ConfirmOrder();
    }
}
