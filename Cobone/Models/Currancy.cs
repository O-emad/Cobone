using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class Currency
    {
        public string currency_id { get; set; }
        public string symbol_left { get; set; }
        public string symbol_right { get; set; }
        public string decimal_place { get; set; }
        public string value { get; set; }
    }
}
