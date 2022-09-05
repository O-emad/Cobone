﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class PaymobPaymentRequest
    {
        public string amount_cents { get; set; }
        public string auth_token { get; set; }
        public Billing_Data billing_data { get; set; }
        public string currency { get; set; }
        public int expiration { get; set; }
        public int integration_id { get; set; }
        public string lock_order_when_paid { get; set; }
        public string order_id { get; set; }
    }

    public class Billing_Data
    {
        public string apartment { get; set; }
        public string building { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string floor { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public string postal_code { get; set; }
        public string shipping_method { get; set; }
        public string state { get; set; }
        public string street { get; set; }
    }

}
