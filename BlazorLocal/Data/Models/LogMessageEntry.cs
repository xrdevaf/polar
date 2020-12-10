using System;

namespace BlazorLocal.Data.Models
{
    public class LogMessageEntry
    {
        public string ErrorMsg { get; set; }
        public string ErrorContext { get; set; }
        public string ErrorMsgUser { get; set; }
        public DateTime InsertDate { get; set; }
        public string UserData { get; set; }
        public int? ErrorLevel { get; set; }
    }
}
