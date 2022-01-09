using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class Home
    {
        public Slider[]? Slider { get; set; }
        public HomeProduct[]? Latest { get; set; }
        public HomeProduct[]? Specials { get; set; }
        public HomeProduct[]? BestSeller { get; set; }
        public Featured[]? Featured { get; set; }
    }
}
