using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class ProductOption
    {
        public int product_option_id { get; set; }
        public Option_Value[] option_value { get; set; }
        public int option_id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public string required { get; set; }
    }

    public class Option_Value
    {
        public string image { get; set; }
        public float price { get; set; }
        public string price_formated { get; set; }
        public float price_excluding_tax { get; set; }
        public string price_excluding_tax_formated { get; set; }
        public string price_prefix { get; set; }
        public int product_option_value_id { get; set; }
        public int option_value_id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
    }

}
