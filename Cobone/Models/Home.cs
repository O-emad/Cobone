using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class Home
    {
        public List<Slider>? Slider { get; set; }
        public List<Product>? Latest { get; set; }
        public List<Product>? Specials { get; set; }
        public List<Product>? BestSeller { get; set; }
        public Featured[]? Featured { get; set; }
    }
}
