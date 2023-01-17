using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class CartItem
    {
        public string product_id { get; set; }
        public string quantity { get; set; }
        public Dictionary<string,string> option { get; set; }
    }

}
