using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class ForgotPassword
    {
        [Remote("ValidateEmail", "Authentication", AdditionalFields = "Id")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e - mail")]
        [Required(ErrorMessage = "Please enter an email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Password must be at least 8 digits long.", MinimumLength = 8)]
        //[System.ComponentModel.DataAnnotations.RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 digits and the following 4: Upper case (A-Z), Lower case (a-z), number (0-9) And special character (E.x.! @ # $% ^ & *)")]
        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }


    }
}
