using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public interface IAccountDataService
    {
        Task<AccountDetails> GetAccountDetails();
        Task Login(AccountLogin accountLogin);
        Task ForgotPassword(AccountForgotPassword accountForgotPassword);
        Task Register(AccountRegister accountRegister);
        Task Logout();

        Task ChangePassword(AccountPasswordChange passwordChange);
        Task UpdateAccountDetails(AccountUpdateDetails accountUpdate);

    }
}
