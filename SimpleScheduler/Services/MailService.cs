using Hangfire;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleScheduler.Services
{
    public class MailService
    {
        private IConfiguration _config;
        public MailService(IConfiguration configuration)
        {
            _config = configuration;

        }

        public void SendMail(string toAddress, string body, IJobCancellationToken cancellationToken)
        {
            string FromMail = _config["Data:FromMail"];
            string FromTitle = _config["Data:FromTitle"];
            string Password = _config["Data:Password"];
            int Port = int.Parse(_config["Data:Port"]);
            string SmtpServer = _config["Data:SmtpServer"];

            string ToAddress = toAddress;
            string Subject = "Hello World - Sending email using ASP.NET Core 1.1";
            string BodyContent = body;

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(FromTitle, FromMail));
            mimeMessage.To.Add(new MailboxAddress(ToAddress));
            mimeMessage.Subject = Subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = BodyContent

            };
            try
            {
                using (var client = new SmtpClient())
                {

                    client.Connect(SmtpServer, Port, false);
                    // Note: only needed if the SMTP server requires authentication
                    // Error 5.5.1 Authentication 
                    client.Authenticate(FromMail, Password);
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }
            }
            catch (Exception)
            {
                  //normally error would be logged somewhere here
            }
           
        }
    }
}
