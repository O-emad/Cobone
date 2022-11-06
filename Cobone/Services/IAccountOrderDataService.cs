using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public interface IAccountOrderDataService
    {
        Task<List<AccountOrder>> GetAccountOrders(int page, int pageSize);
        Task<AccountOrderDetails> GetAccountOrderDetails(int id);
    }
}
