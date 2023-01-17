using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class User
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string company { get; set; }
        public string city { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public int country_id { get; set; }
        public string postcode { get; set; }
        public int zone_id { get; set; }
    }

}
