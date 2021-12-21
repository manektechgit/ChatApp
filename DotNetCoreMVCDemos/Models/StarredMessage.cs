using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVCDemos.Models
{
    public class StarredMessage
    {
        public string Message { get; set; }
        public string MessageTime { get; set; }
        [NotMapped]
        public string DocUrl { get; set; }
    }
}
