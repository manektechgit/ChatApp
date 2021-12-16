using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class GroupChatConversation
    {
        public List<GroupMessages> GroupMessages { get; set; }
        public string GroupId { get; set; }
        public string UserId { get; set; }
        public string GroupName { get; set; }
        public int TotalMembers { get; set; }
    }
    public class GroupMessages
    {
        //public int ConversationID { get; set; }
        public string Message { get; set; }
        public string MessageTime { get; set; }
        public string UserID { get; set; }
        public string ChatUserID { get; set; }
        public byte IsRead { get; set; }
        public string ProfileImage { get; set; }
        public string Name { get; set; }
        public string GroupMsgID { get; set; }
        public bool IsStar { get; set; }
        [NotMapped]
        public string DocUrl { get; set; }

    }
}
