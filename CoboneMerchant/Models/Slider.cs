using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class Slider
    {
        public int Module_Id { get; set; }
        public string? Name { get; set; }
        public int Banner_Id { get; set; }
        public string? Width { get; set; }
        public string? Height { get; set; }
        public string? Status { get; set; }
        public Banner[]? Banners { get; set; }
    }
}
