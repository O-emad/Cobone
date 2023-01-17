using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class AccountRegisterResponse
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Customer_Group_Id { get; set; }
        public object[] Custom_Field { get; set; }
        public CustomerGroups[] Customer_Groups { get; set; }
        public string Company { get; set; }
        public int Customer_Id { get; set; }
        public string Address_Id { get; set; }
    }

    public class CustomerGroups
    {
        public string Customer_Group_Id { get; set; }
        public string Approval { get; set; }
        public string Sort_Order { get; set; }
        public string Language_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
