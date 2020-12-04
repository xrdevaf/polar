using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.Data.Models;

namespace BlazorLocal.Data.Services.MailingServices
{
    public class BaseMailingService
    {
        protected MailSenderComponent mEmailClient;
        protected MailSettings mMailSettings;
        public BaseMailingService(MailSettings mailSettings)
        {
            try
            {
                mMailSettings = mailSettings;
                //mEmailClient = new MailSenderComponent(new SmtpConfig(
                //    "smtp.strato.de", 587,
                //    "relay@alfatraining.de", "Afupifufu546"));

                mEmailClient = new MailSenderComponent(new SmtpConfig(
                    mailSettings.SMTP_SERVER, int.Parse(mailSettings.SMTP_PORT),
                    mailSettings.SMTP_USERNAME, mailSettings.SMTP_PASSWORD));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
