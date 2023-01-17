using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class Cart
    {
        public string weight { get; set; }
        public CartProduct[] products { get; set; }
        public object[] vouchers { get; set; }
        public string coupon_status { get; set; }
        public string coupon { get; set; }
        public string voucher_status { get; set; }
        public string voucher { get; set; }
        public bool reward_status { get; set; }
        public string reward { get; set; }
        public CartTotal[] totals { get; set; }
        public string total { get; set; }
        public int total_raw { get; set; }
        public int total_product_count { get; set; }
        public int has_shipping { get; set; }
        public int has_download { get; set; }
        public int has_recurring_products { get; set; }
        public CartCurrency currency { get; set; }
    }

    public class CartCurrency
    {
        public string currency_id { get; set; }
        public string symbol_left { get; set; }
        public string symbol_right { get; set; }
        public string decimal_place { get; set; }
        public string value { get; set; }
    }

    public class CartProduct
    {
        public string key { get; set; }
        public string thumb { get; set; }
        public string name { get; set; }
        public int points { get; set; }
        public string product_id { get; set; }
        public string model { get; set; }
        public CartOption[] option { get; set; }
        public string quantity { get; set; }
        public string recurring { get; set; }
        public bool stock { get; set; }
        public string reward { get; set; }
        public string price { get; set; }
        public string total { get; set; }
        public int price_raw { get; set; }
        public int total_raw { get; set; }
    }

    public class CartTotal
    {
        public string title { get; set; }
        public string text { get; set; }
        public int value { get; set; }
    }

    public class CartOption
    {
        public string name { get; set; }
        public string value { get; set; }
    }

}
