using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlazorLocal.Data.Models
{
    public class MailData
    {
        public MailAddress FromEmail { get; set; }
        public MailAddress ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<Attachment> AttachmentData { get; set; } = new List<Attachment>();
        public MailAddress BccEmail { get; set; }
    }
}
