using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace DotNetCoreMVCDemos.Models
{
    public class ProfileInfo
    {        
        public string Email { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
                
        public string ProfileImage { get; set; }
        public string Facebook { get; set; }
        public string Snapchat { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }
}
