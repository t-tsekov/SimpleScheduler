using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleScheduler.ViewModels
{
    public class TaskViewModel
    {   
        [Required]
        [Display(Name = "Recipient Email Address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Message Text")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        [Display(Name = "Time to run the task")]
        [DataType(DataType.DateTime)]
        public DateTime TimeToStart { get; set; }


    }
}
