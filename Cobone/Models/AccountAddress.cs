using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class AccountAddress
    {
        public string address_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string company { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string zone_id { get; set; }
        public string zone { get; set; }
        public string zone_code { get; set; }
        public string country_id { get; set; }
        public string country { get; set; }
        public string iso_code_2 { get; set; }
        public string iso_code_3 { get; set; }
        public string address_format { get; set; }
        public object custom_field { get; set; }
        public bool _default { get; set; }
    }

    public class AccountAddressResposne
    {
        public List<AccountAddress> Addresses { get; set; }
    }

}
