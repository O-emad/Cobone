using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public interface IOrderStatusDataService
    {
        Task<List<OrderStatus>> GetOrderStatuses();
        Task<bool> RedeemOfferOnOrder(string id);
    }
}
