using CoboneMerchant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Services
{
    public interface IAccountAddressDataService
    {
        Task<IEnumerable<AccountAddress>> GetAccountAddresses();
        Task AddAccountAddress(AccountAddress accountAddress);
        Task RemoveAccountAddress(string id);
    }
}
