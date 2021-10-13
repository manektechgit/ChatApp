using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class GroupCreate
    {
        [StringLength(50, ErrorMessage = "Password must be at least 3 digits long.", MinimumLength = 3)]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 digits and the following 4: Upper case (A-Z), Lower case (a-z), number (0-9) And special character (E.x.! @ # $% ^ & *)")]
        [Required(ErrorMessage = "Please enter a Group Name")]
        public string GroupName { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
