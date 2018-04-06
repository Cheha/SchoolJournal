using System;
using System.ComponentModel.DataAnnotations;
using SchoolJournal.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Areas.Admin.Models
{
    public class TeacherDetailsViewModel
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
            get
            {
                return String.Format("{0} {1} {2}", TeacherLastName, TeacherFirstName, TeacherFatherName);
            }
        }

        //TEACHER AS A USER
        //public string @MAIL {get;set;}
        
        public List<SchoolClass> SchoolClasses { get; set; }
        public List<Subject> Subjects { get; set; }

    }
}