using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class ConversationPanelModel
    {
        public string UserId { get; set; }
        public string ChatUserId { get; set; }
        public string ChatUserName { get; set; }
        public string Lastseen { get; set; }
        public string Message { get; set; }
        public IList<IFormFile> imageArr { get; set; }
    }
}
