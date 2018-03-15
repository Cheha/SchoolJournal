using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolJournal.Domain
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string UserId { get; set; }

        //public int SchoolClassId { get; set; }
        //public SchoolClass SchoolClass { get; set; }
    }
}