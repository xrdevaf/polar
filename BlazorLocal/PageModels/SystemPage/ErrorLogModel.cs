using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLocal.PageModels
{
    public class ErrorLogModel
    {
        public int Id { get; set; }
        public string ErrorContext { get; set; }
        public string ErrorMsgUser { get; set; }
        public string ErrorMsg { get; set; }
        public DateTime InsertDate { get; set; }
        public string UserData { get; set; }
        public int? ErrorLevel { get; set; }
    }
}
