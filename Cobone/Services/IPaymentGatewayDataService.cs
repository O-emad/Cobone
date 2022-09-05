using Cobone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Services
{
    public interface IPaymentGatewayDataService
    {
        Task<string> AuthenticationRequest();
        Task<PaymobOrderRegisterResponse> OrderRegister(PaymobOrderRegisterRequest request);
        Task<PaymobPaymentResponse> PaymentRequest(PaymobPaymentRequest request);

    }
}
