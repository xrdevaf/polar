using BlazorLocal.Data.Models;
using BlazorLocal.Data.Services.MailingServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlazorLocal.Data.Services
{
    public class TestControlMailingService : BaseMailingService
    {
        private readonly ILogger _logger;
        public TestControlMailingService(ApplicationDbContext context, ILogger logger) : base(context)
        {
            _logger = logger;
        }
        public void SendTestMail(string toEmail, string fromEmail)
        {
            var mailData = new MailData();
            mailData.ToEmail = new MailAddress(toEmail);
            mailData.FromEmail = new MailAddress(fromEmail);
            mailData.BccEmail = new MailAddress(toEmail);

            mailData.Subject = "Test Email Alfatraining";
            mailData.Body = "It's Test Email Alfatraining BMW CH";

            SendMail(mailData);
        }

    }
}
