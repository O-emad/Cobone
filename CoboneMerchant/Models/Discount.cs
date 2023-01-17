using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class Discount
    {
        public int Quantity { get; set; }
        public float Price_Excluding_Tax { get; set; }
        public string? Price_Excluding_Tax_Formated { get; set; }
        public float Price { get; set; }
        public string? Price_Formated { get; set; }
    }
}
