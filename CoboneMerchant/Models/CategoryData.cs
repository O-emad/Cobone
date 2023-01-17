using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class CategoryData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string original_image { get; set; }
        public Filters filters { get; set; }
        public string seo_url { get; set; }
        public List<Category> sub_categories { get; set; }
    }



}
