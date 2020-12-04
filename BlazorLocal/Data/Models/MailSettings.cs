using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLocal.Data.Models
{
    public class MailSettings
    {
        public string SMTP_SERVER { get; set; }
        public string SMTP_PORT { get; set; }
        public string SMTP_USERNAME { get; set; }
        public string SMTP_PASSWORD { get; set; }
        public string FROM { get; set; }
        public string BCC { get; set; }
    }
}
