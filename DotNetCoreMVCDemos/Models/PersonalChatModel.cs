using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class PersonalChatModel
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Lastseen { get; set; }
        public string LastMessage { get; set; }
        public string LastMessageTime { get; set; }   
        public int MessageCount { get; set; }
    }
}
