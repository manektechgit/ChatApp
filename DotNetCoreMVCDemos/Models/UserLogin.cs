using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class UserLogin
    {
        [Remote("ValidateEmail", "Authentication", AdditionalFields = "Id")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e - mail")]
        [Required(ErrorMessage = "Please enter an email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Password must be at least 8 digits long.", MinimumLength = 8)]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 digits and the following 4: Upper case (A-Z), Lower case (a-z), number (0-9) And special character (E.x.! @ # $% ^ & *)")]
        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string ProfileImage { get; set; }
        public string Facebook { get; set; }
        public string Snapchat { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Theme { get; set; }

    }
    public class CallOffer
    {
        public User Caller { get; set; }
        public User Callee { get; set; }
    }

    public class User
    {
        public string Username { get; set; }
        public string ConnectionId { get; set; }
        public bool InCall { get; set; }
    }
    public class UserCall
    {
        public List<User> Users { get; set; }
    }
}
