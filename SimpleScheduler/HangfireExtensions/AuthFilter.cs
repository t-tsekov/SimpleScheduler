using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire.Annotations;

namespace SimpleScheduler.HangfireExtensions
{
    public class AuthFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            //normally there would be some police or role based authentication here
            return true;
        }
    }
}
