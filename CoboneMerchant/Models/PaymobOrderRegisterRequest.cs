using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class PaymobOrderRegisterRequest
    {
        public string amount { get; set; }
        public string currency { get; set; }
        public string token { get; set; }
    }

}
