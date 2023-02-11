using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class RelatedProducts
    {
        public int product_id { get; set; }
        public string seo_url { get; set; }
        public string thumb { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public string stock_status { get; set; }
        public float price_excluding_tax { get; set; }
        public string price_excluding_tax_formated { get; set; }
        public float price { get; set; }
        public string price_formated { get; set; }
        public float special { get; set; }
        public string special_formated { get; set; }
        public float special_excluding_tax { get; set; }
        public string special_excluding_tax_formated { get; set; }
        //public object[] discounts { get; set; }
        public int rating { get; set; }
        public string description { get; set; }
    }

}
