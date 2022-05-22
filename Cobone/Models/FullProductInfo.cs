using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class FullProductInfo
    {
            public int Id { get; set; }
            public int Product_Id { get; set; }
            public string Name { get; set; }
            public string Manufacturer { get; set; }
            public string Sku { get; set; }
            public string Model { get; set; }
            public string Image { get; set; }
            public string[] Images { get; set; }
            public string Original_Image { get; set; }
            public string[] Original_Images { get; set; }
            public float Price_Excluding_Tax { get; set; }
            public string Price_Excluding_Tax_Formated { get; set; }
            public float Price { get; set; }
            public string Price_Formated { get; set; }
            public float Rating { get; set; }
            public string Description { get; set; }
            //public object[] attribute_groups { get; set; }
            public float Special { get; set; }
            public float Special_Excluding_Tax { get; set; }
            public string Special_Excluding_Tax_Formated { get; set; }
            public string Special_Formated { get; set; }
            public string Special_Start_Date { get; set; }
            public string Special_End_Date { get; set; }
            //public object[] discounts { get; set; }
            //public object[] options { get; set; }
            public string Minimum { get; set; }
            public string Meta_Title { get; set; }
            public string Meta_Description { get; set; }
            public string Meta_Keyword { get; set; }
            public string Seo_Url { get; set; }
            public string Tag { get; set; }
            public string Upc { get; set; }
            public string Ean { get; set; }
            public string Jan { get; set; }
            public string Isbn { get; set; }
            public string Mpn { get; set; }
            public string Location { get; set; }
            public string Stock_Status { get; set; }
            public int Stock_Status_Id { get; set; }
            public int Manufacturer_Id { get; set; }
            public int Tax_Class_Id { get; set; }
            public string Date_Available { get; set; }
            public string Weight { get; set; }
            public int Weight_Class_Id { get; set; }
            public string Length { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
            public int Length_Class_Id { get; set; }
            public string Subtract { get; set; }
            public string Sort_Order { get; set; }
            public string Status { get; set; }
            public string Date_Added { get; set; }
            public string Date_Modified { get; set; }
            public string Viewed { get; set; }
            public string Weight_Class { get; set; }
            public string Length_Class { get; set; }
            public string Shipping { get; set; }
            public string Reward { get; set; }
            public string Points { get; set; }
            public MinifiedCategory[] Category { get; set; }
            public int Quantity { get; set; }
            public Reviews Reviews { get; set; }
            //public object[] recurrings { get; set; }
        
    }

    public class Reviews
    {
        public string Review_Total { get; set; }
    }

    public class MinifiedCategory
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
