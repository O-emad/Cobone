using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class PaymentMethod
    {
        public string code { get; set; }
        public string title { get; set; }
        public string terms { get; set; }
        public string sort_order { get; set; }
    }


    public class PaymentMethodResponse
    {
        public PaymentMethod[] payment_methods { get; set; }
    }

}
