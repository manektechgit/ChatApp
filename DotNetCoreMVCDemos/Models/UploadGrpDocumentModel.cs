using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class UploadGrpDocumentModel
    {
        public List<GrpFileDetail> File { get; set; }
        public string UserId { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
    }
    public class GrpFileDetail
    {
        public string url { get; set; }
    }
}
