using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models
{
    public class StudentViewModel
    {
        public string StudentId { get; set; }

        [Display(Name = "First name")]
        public string StudentFirstName { get; set; }

        [Display(Name = "Last name")]
        public string StudentLastName { get; set; }

        [Display(Name = "Full name")]
        public string StudentFullName
        {
            get
            {
                return String.Format("{0} {1}", StudentLastName, StudentFirstName);
            }
        }

        public string SchoolClassId { get; set; }
    }
}