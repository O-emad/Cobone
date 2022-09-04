using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public interface IPaymentAddressDataService
    {
        Task<PaymentAddress> GetPaymentAddress();
        Task AddPaymentAddress(PaymentAddress address);
        Task SelectExistingPaymentAddress(string paymentAddressId);
    }
}
