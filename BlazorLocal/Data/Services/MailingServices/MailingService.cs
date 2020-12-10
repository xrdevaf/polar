using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using BlazorLocal.Data.Models;
using BlazorLocal.PageModels;
using BlazorLocal.Shared;

namespace BlazorLocal.Data.Services.MailingServices
{
    public class MailingService : BaseMailingService
    {
        public MailingService(ApplicationDbContext context) : base(context)
        {
        }

        public bool SendMessage(EmailModel model)
        {
            var mailData = new MailData();
            mailData.ToEmail = new MailAddress(model.To);        
            mailData.FromEmail = new MailAddress(model.From);
            mailData.BccEmail = new MailAddress(model.From);

            try
            {
                mailData.Subject = model.Subject;
                mailData.Body = model.Body;
               // mailData.AttachmentData = AddAttachmentList(item).GetAwaiter().GetResult();

               SendMail(mailData);
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
    }
}
