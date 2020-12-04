using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using BlazorLocal.Data.Models;
using BlazorLocal.PageModels;

namespace BlazorLocal.Data.Services.MailingServices
{
    public class MailingService : BaseMailingService
    {
        public MailingService(MailSettings settings) : base(settings)
        {
        }
        public bool SendMessage(AuftragItemViewModel item, string from)
        {
            var mailData = new MailData();
            //mailData.ToEmail = new MailAddress(to);        
            mailData.ToEmail = new MailAddress(@"arthur.fischer@alfatraining.de"); //For TEST-CASE!!!      
            // mailData.ToEmail = new MailAddress(@"aleksa06101@gmail.com"); //For TEST-CASE!!!      
            mailData.FromEmail = new MailAddress(mMailSettings.FROM);
            mailData.BccEmail = new MailAddress(mMailSettings.BCC);

            try
            {
                mailData.Subject = "Anfrage Subject";
                mailData.Body = GetBody(item);
               // mailData.AttachmentData = AddAttachmentList(item).GetAwaiter().GetResult();

                mEmailClient.SendMail(mailData);
            }
            catch (Exception ex)
            {
                //TODO: Logging
                Console.WriteLine(ex);
                var messageExc = ex.Message;
                if (ex.InnerException != null)
                {
                    messageExc += ex.InnerException;
                    throw new Exception(messageExc);
                }

                throw new Exception(messageExc);
            }

            return true;
        }

        private string GetBody(AuftragItemViewModel item)
        {
            string body = string.Empty;
            body += item.AuftragId + " " + item.Kunde?.Trim() + " " + item.Laufnummer?.Trim();

            return body;
        }
    }
}
