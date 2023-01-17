using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public interface IMerchantDataService
    {
        Task<AccountOrderDetails> GetOrderById(int id);
    }
}
