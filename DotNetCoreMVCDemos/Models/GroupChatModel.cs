using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class GroupChatModel
    {
        public string GroupName { get; set; }
        public string LastMessage { get; set; }
        public string LastMessageTime { get; set; }
        public int MessageCount { get; set; }
        public int TotalMembers { get; set; }
        public string GroupID { get; set; }
    }
}
