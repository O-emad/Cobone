using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public interface ICartDataService
    {
        Task AddToCart(CartItem item);
        Task<Cart> GetCartItems();
        Task DeleteCartItem(string key);
    }
}
