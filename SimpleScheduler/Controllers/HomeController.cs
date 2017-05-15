using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hangfire;
using SimpleScheduler.Services;
using SimpleScheduler.ViewModels;

namespace SimpleScheduler.Controllers
{
    public class HomeController : Controller
    {
        private IMailSender _mailService; 
        public HomeController(IMailSender mailService)
        {
            _mailService = mailService;

        }

        [HttpGet]
        public  IActionResult Index()
        {
            ViewData["Message"] = "Create a new task";
            return View();
        }

        [HttpPost]
        public IActionResult Index(TaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            else if(model.TimeToStart < DateTime.Now)
            {
                ViewData["Message"] = "Please enter a future date";
                return View(model);
            }

            BackgroundJob.Schedule<IMailSender>((sender) => sender.SendMail(model.Email, model.Body, JobCancellationToken.Null), model.TimeToStart);
            ViewData["Message"] = "Task saved.";
            return View();
        }

    }
}
