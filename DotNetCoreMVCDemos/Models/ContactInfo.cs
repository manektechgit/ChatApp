using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class ContactInfo
    {
        public string Email { get; set; }
        public int UserId { get; set; }
        public string ChatUserName { get; set; }
        public string MobileNumber { get; set; }

        public int TotalMediaFile { get; set; }
        public int TotalDocumentFile { get; set; }
        public string ProfileImage { get; set; }

        public List<ImageDetails> Image { get; set; }

        public List<string> ShowImageURL { get; set; }

        public List<string> Documents { get; set; }
    }
}
