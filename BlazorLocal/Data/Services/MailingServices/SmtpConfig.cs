using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlazorLocal.Data.Services.MailingServices
{
    public class SmtpConfig
    {
        public string SmtpServer { get; private set; }
        public NetworkCredential NetworkCredentials { get; set; }
        public int Port { get; set; }

        public SmtpConfig(string smtpServer, int smptPort, string username, string passwort)
        {
            SmtpServer = smtpServer;
            Port = smptPort;
            NetworkCredentials = new NetworkCredential(username, passwort);
        }
    }
}
