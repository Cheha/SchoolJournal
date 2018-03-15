using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models
{
    public class TeacherProfileViewModel
    {
        public TeacherViewModel Teacher { get; set; }
        [Display(Name = "Class")]
        public List<SchoolClassViewModel> SchoolClasses { get; set; }
    }
}