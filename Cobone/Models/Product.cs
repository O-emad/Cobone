using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Cobone.Models
{
    public class Product
    {
        public int Product_Id { get; set; }
        public string? Seo_Url { get; set; }
        public string? Thumb { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public string? Status { get; set; }
        public string? Stock_Status { get; set; }
        public float Price_Excluding_Tax { get; set; }
        public string? Price_Excluding_Tax_Formated { get; set; }
        public float Price { get; set; }
        public string? Price_Formated { get; set; }
        public float Special { get; set; }
        public string? Special_Formated { get; set; }
        public float Special_Excluding_Tax { get; set; }
        public string? Special_Excluding_Tax_Formated { get; set; }
        public float Rating { get; set; }
        public string? Description { get; set; }


        public string? Special_Start_Date { get; set; }
        public string? Special_End_Date { get; set; }

    }
}
