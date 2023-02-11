using Cobone.Shared.ResourceFiles;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Models
{
    public class AccountRegister
    {
       


        [Required(ErrorMessageResourceType = typeof(Resource),ErrorMessageResourceName = nameof(Resource.register_required_message))]
        //[StringLength(50, ErrorMessage = "Name length can't be less than 1.")]
        public string Firstname { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.register_required_message))]
        //[StringLength(50, ErrorMessage = "Name length can't be less than 1.")]
        public string Lastname { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.register_required_message))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.register_email_invalid_message))]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.register_required_message))]
        //[StringLength(50, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.register_required_message))]
        [Compare(nameof(Password), ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.register_password_match_message))]
        public string Confirm { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource),ErrorMessageResourceName = nameof(Resource.register_required_message))]
        [Phone(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = nameof(Resource.register_phone_invalid_message))]
        public string Telephone { get; set; }
        public int Customer_Group_Id { get; set; }
        public int Agree { get; set; }
        public Custom_Field Custom_Field { get; set; }
    }
}

public class Custom_Field
{
}

