using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models
{
    public class TeacherViewModel
    {
        public string TeacherId { get; set; }

        [Display(Name = "First name")]
        public string TeacherFirstName { get; set; }

        [Display(Name = "Last name")]
        public string TeacherLastName { get; set; }

        [Display(Name = "Father name")]
        public string TeacherFatherName { get; set; }

        [Display(Name = "Full name")]
        public string TeacherFullName
        {
            get {
                return String.Format("{0} {1}", TeacherLastName, TeacherFirstName);
            }
        }
    }
}