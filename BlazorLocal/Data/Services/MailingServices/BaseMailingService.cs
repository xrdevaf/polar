using BlazorLocal.Data;
using BlazorLocal.Data.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlazorLocal.Data.Services.MailingServices
{
    public class BaseMailingService : IEmailSender
    {
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;

        public BaseMailingService(ApplicationDbContext context)
        {
            var setting = context.SMTPSettingDbSet.FirstOrDefault(r => r.IsActive);

            if (setting != null)
            {
                this.host = setting.SMTPServer;
                this.port = setting.SMTPPort;
                this.enableSSL = setting.EnableSSL;
                this.userName = setting.SMTPUsername;
                this.password = setting.SMTPPassword;
            }
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(userName, email, subject, htmlMessage) { IsBodyHtml = true }
            );
        }

        public void SendMail(MailData mailData)
        {
            if (string.IsNullOrEmpty(mailData.FromEmail.Address))
                throw new Exception("MAIL_FROM: ist leer");

            if (string.IsNullOrEmpty(mailData.ToEmail.Address))
                throw new Exception("MAIL_TO: ist leer");

            var message = new MailMessage();
            try
            {
                message.From = mailData.FromEmail;
                message.To.Add(mailData.ToEmail);
                message.Bcc.Add(mailData.BccEmail);
                message.Subject = mailData.Subject;
                message.Body = mailData.Body;
                message.IsBodyHtml = false;

                if (mailData.AttachmentData != null)
                {
                    foreach (var att in mailData.AttachmentData)
                    {
                        message.Attachments.Add(att);
                    }
                }

                var client = new SmtpClient(host, port)
                {
                    Credentials = new NetworkCredential(userName, password),
                    EnableSsl = enableSSL
                };

                client.Send(message);

            }
            catch (Exception xpt)
            {
                var messageExc = xpt.Message;
                if (xpt.InnerException != null)
                {
                    messageExc += xpt.InnerException;
                    throw new Exception(messageExc);
                }

                throw new Exception(messageExc + " " + mailData.ToEmail);
            }

            //Logger.Write("BoiMailSender.SendMail(): Mail verschickt an " + message.To);
            return;
        }
    }
}
