using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class Category
    {

            public int Category_Id { get; set; }
            public int Parent_Id { get; set; }
            public string? Name { get; set; }
            public string? Seo_Url { get; set; }
            public string? Image { get; set; }
            public string? Original_Image { get; set; }
            public Filters? Filters { get; set; }
            public List<Category>? Categories { get; set; }
        
    }
}
