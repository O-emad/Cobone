using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    //get 200 when u find details get 403 when you are not logged in
    public class AccountDetails
    {
        public string Customer_Id { get; set; }
        public string Customer_Group_Id { get; set; }
        public string Store_Id { get; set; }
        public string Language_Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Cart { get; set; }
        public string Wishlist { get; set; }
        public string Newsletter { get; set; }
        public string Address_Id { get; set; }
        public string Ip { get; set; }
        public string Status { get; set; }
        public string Safe { get; set; }
        public string Token { get; set; }
        public string Code { get; set; }
        public string Date_Added { get; set; }
        public object Account_Custom_Field { get; set; }
        public string Reward_Total { get; set; }
        public string User_Balance { get; set; }

    }


}
