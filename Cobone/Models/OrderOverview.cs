using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class OrderOverview
    {
        public Total[] totals { get; set; }
        public string invoice_prefix { get; set; }
        public int store_id { get; set; }
        public string store_name { get; set; }
        public string store_url { get; set; }
        public string customer_id { get; set; }
        public string customer_group_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string fax { get; set; }
        public object custom_field { get; set; }
        public string payment_firstname { get; set; }
        public string payment_lastname { get; set; }
        public string payment_company { get; set; }
        public string payment_address_1 { get; set; }
        public string payment_address_2 { get; set; }
        public string payment_city { get; set; }
        public string payment_postcode { get; set; }
        public string payment_zone { get; set; }
        public string payment_zone_id { get; set; }
        public string payment_country { get; set; }
        public string payment_country_id { get; set; }
        public string payment_address_format { get; set; }
        public object payment_custom_field { get; set; }
        public string payment_method { get; set; }
        public string payment_code { get; set; }
        public string shipping_firstname { get; set; }
        public string shipping_lastname { get; set; }
        public string shipping_company { get; set; }
        public string shipping_address_1 { get; set; }
        public string shipping_address_2 { get; set; }
        public string shipping_city { get; set; }
        public string shipping_postcode { get; set; }
        public string shipping_zone { get; set; }
        public string shipping_zone_id { get; set; }
        public string shipping_country { get; set; }
        public string shipping_country_id { get; set; }
        public string shipping_address_format { get; set; }
        public object[] shipping_custom_field { get; set; }
        public string shipping_method { get; set; }
        public string shipping_code { get; set; }
        public OrderSummaryProduct[] products { get; set; }
        public object[] vouchers { get; set; }
        public string comment { get; set; }
        public int total { get; set; }
        public int affiliate_id { get; set; }
        public int commission { get; set; }
        public int marketing_id { get; set; }
        public string tracking { get; set; }
        public string language_id { get; set; }
        public string currency_id { get; set; }
        public string currency_code { get; set; }
        public string currency_value { get; set; }
        public string ip { get; set; }
        public string forwarded_ip { get; set; }
        public string user_agent { get; set; }
        public string accept_language { get; set; }
        public string order_id { get; set; }
        public string payment { get; set; }
    }

    public class Total
    {
        public string title { get; set; }
        public string text { get; set; }
    }

    public class OrderSummaryProduct
    {
        public string key { get; set; }
        public string product_id { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public object[] option { get; set; }
        public string recurring { get; set; }
        public string image { get; set; }
        public string quantity { get; set; }
        public string subtract { get; set; }
        public string price { get; set; }
        public string total { get; set; }
        public string href { get; set; }
    }



}
