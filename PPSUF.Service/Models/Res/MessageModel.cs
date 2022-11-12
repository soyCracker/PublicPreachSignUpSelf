using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPSUF.Service.Models.Res
{
    public class MessageModel<T>
    {
        public bool Success { get; set; } = true;
        public string StatusCode { get; set; } = "200";
        public string Msg { get; set; } = "";
        public T Data{get; set; }
    }
}