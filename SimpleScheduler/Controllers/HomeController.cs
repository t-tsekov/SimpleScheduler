using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hangfire;
using SimpleScheduler.Services;

namespace SimpleScheduler.Controllers
{
    public class HomeController : Controller
    {
        private MailService _mailService; 
        public HomeController(MailService mailService)
        {
            _mailService = mailService;
        }
        public  IActionResult Index()
        {
            //BackgroundJob.Enqueue( () => _mailService.SendMail("77rvg77@gmail.com", "test mail", JobCancellationToken.Null)); 
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
