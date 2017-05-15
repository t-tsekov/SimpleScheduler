using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleScheduler.Services
{
    public interface IMailSender
    {
        void SendMail(string toAddress, string body, IJobCancellationToken cancellationToken);
    }
}
