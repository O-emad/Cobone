using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class AccountRegister
    {
        [Required]
        [StringLength(8, ErrorMessage = "Name length can't be less than 1.")]
        public string Firstname { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "Name length can't be less than 1.")]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string Confirm { get; set; }
        [Required]
        [Phone]
        public string Telephone { get; set; }
        public int Customer_Group_Id { get; set; }
        public int Agree { get; set; }
        public Custom_Field Custom_Field { get; set; }
    }
}

public class Custom_Field
{
}

