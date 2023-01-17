using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class AccountOrderDetails
    {
            public string order_id { get; set; }
            public object payment_custom_field { get; set; }
            public object[] shipping_custom_field { get; set; }
            public object custom_field { get; set; }
            public string invoice_no { get; set; }
            public string invoice_prefix { get; set; }
            public string store_id { get; set; }
            public string store_name { get; set; }
            public string store_url { get; set; }
            public string customer_id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string telephone { get; set; }
            public string email { get; set; }
            public string payment_firstname { get; set; }
            public string payment_lastname { get; set; }
            public string payment_company { get; set; }
            public string payment_address_1 { get; set; }
            public string payment_address_2 { get; set; }
            public string payment_postcode { get; set; }
            public string payment_city { get; set; }
            public string payment_zone_id { get; set; }
            public string payment_zone { get; set; }
            public string payment_zone_code { get; set; }
            public string payment_country_id { get; set; }
            public string payment_country { get; set; }
            public string payment_iso_code_2 { get; set; }
            public string payment_iso_code_3 { get; set; }
            public string payment_address_format { get; set; }
            public string payment_method { get; set; }
            public string shipping_firstname { get; set; }
            public string shipping_lastname { get; set; }
            public string shipping_company { get; set; }
            public string shipping_address_1 { get; set; }
            public string shipping_address_2 { get; set; }
            public string shipping_postcode { get; set; }
            public string shipping_city { get; set; }
            public string shipping_zone_id { get; set; }
            public string shipping_zone { get; set; }
            public string shipping_zone_code { get; set; }
            public string shipping_country_id { get; set; }
            public string shipping_country { get; set; }
            public string shipping_iso_code_2 { get; set; }
            public string shipping_iso_code_3 { get; set; }
            public string shipping_address_format { get; set; }
            public string shipping_method { get; set; }
            public string comment { get; set; }
            public string total { get; set; }
            public string order_status_id { get; set; }
            public string language_id { get; set; }
            public string currency_id { get; set; }
            public string currency_code { get; set; }
            public string currency_value { get; set; }
            public string date_modified { get; set; }
            public string date_added { get; set; }
            public string ip { get; set; }
            public string payment_address { get; set; }
            public string shipping_address { get; set; }
            public OrderProduct[] products { get; set; }
            public object[] vouchers { get; set; }
            public OrderTotal[] totals { get; set; }
            public OrderHistory[] histories { get; set; }
            public int timestamp { get; set; }
            public Currency currency { get; set; }
        }

    public class OrderProduct
    {
        public string product_id { get; set; }
        public string order_product_id { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public object[] option { get; set; }
        public string quantity { get; set; }
        public string price { get; set; }
        public string total { get; set; }
        public int price_raw { get; set; }
        public string _0 { get; set; }
        public int total_raw { get; set; }
        public string _return { get; set; }
    }

    public class OrderTotal
    {
        public string order_total_id { get; set; }
        public string order_id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public string sort_order { get; set; }
    }

    public class OrderHistory
    {
        public string date_added { get; set; }
        public string status { get; set; }
        public string comment { get; set; }
    }

}
