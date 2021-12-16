using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class ChatConversation
    {
        public List<Messages> Messages { get; set; }
        public string UserId { get; set; }
        public string ChatUserId { get; set; }
        public string ChatUserName { get; set; }
        public string Lastseen { get; set; }
        public string ProfileImage { get; set; }
    }
    public class Messages
    {
        public int ConversationID { get; set; }
        public string Message { get; set; }
        public string MessageTime { get; set; }
        public string UserID { get; set; }
        public byte IsRead { get; set; }
        [NotMapped]
        public string DocUrl { get; set; }
        public string ProfileImage { get; set; }
        public string Name { get; set; }
        public bool IsStar { get; set; }
    }
}
