using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class ShippingMethod
    {
        public string title { get; set; }
        public Quote[] quote { get; set; }
        public string sort_order { get; set; }
        public bool error { get; set; }

    }

    public class Quote
    {
        public string code { get; set; }
        public string title { get; set; }
        public string cost { get; set; }
        public string tax_class_id { get; set; }
        public string text { get; set; }
    }


    public class ShippingMethodResponse
    {
        public ShippingMethod[] shipping_methods { get; set; }
        public string code { get; set; }
        public string comment { get; set; }
    }




}
