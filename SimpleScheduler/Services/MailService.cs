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
    public class MailService  : IMailSender
    {
        private IConfiguration _config;
        private const string FromMailString = "Data:FromMail";
        private const string FromTitleString = "Data:FromTitle";
        private const string PasswordString = "Data:Password";
        private const string PortString = "Data:Port";
        private const string SmtpServerString = "Data:SmtpServer";
        private const string Subject = "Simple Scheduler task fired";

        public MailService(IConfiguration configuration)
        {
            _config = configuration;

        }

        public void SendMail(string toAddress, string body, IJobCancellationToken cancellationToken)
        {
            string FromMail = _config[FromMailString];
            string FromTitle = _config[FromTitleString];
            string Password = _config[PasswordString];
            string SmtpServer = _config[SmtpServerString];
            int Port = int.Parse(_config[PortString]);

            string ToAddress = toAddress;
            string BodyContent = body;

            MimeMessage mimeMessage = new MimeMessage();
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
