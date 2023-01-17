using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public interface IShippingAddressDataService
    {
        Task<ShippingAddress> GetShippingAddress();
        Task AddShippingAddress(ShippingAddress address);
        Task SelectExistingShippingAddress(string shippingAddressId);
    }
}
