using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class AccountOrder
    {
            public string order_id { get; set; }
            public string name { get; set; }
            public string status { get; set; }
            public string date_added { get; set; }
            public int products { get; set; }
            public string total { get; set; }
            public string currency_code { get; set; }
            public string currency_value { get; set; }
            public string total_raw { get; set; }
            public int timestamp { get; set; }
            public Currency currency { get; set; }
        }


    }

