using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class UploadDocumentModel
    {
        //public IList<IFormFile> File { get; set; }
        //public Array[] File { get; set; }
        public List<FileDetail> File { get; set; }
        public string UserId { get; set; }
        public string ChatUserID { get; set; }
    }
    public class FileDetail
    {
        public string url { get; set; }
    }
}
