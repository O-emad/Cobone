using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class Featured
    {
        public int Module_Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public Product[]? Products { get; set; }
    }
}
