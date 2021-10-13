using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class GroupContactInfo
    {
        public string GroupName { get; set; }
        public int TotalMembers { get; set; }
        public int TotalMediaFile { get; set; }
        public int TotalDocumentFile { get; set; }

        public List<ImageDetails> Image { get; set; }

        public List<string> ShowImageURL { get; set; }

        public List<string> Members { get; set; }

        public List<string> Documents { get; set; }
    }
    public class ImageDetails
    {
        public string ImageURL { get; set; }
        public string ImageName { get; set; }
    }
}
