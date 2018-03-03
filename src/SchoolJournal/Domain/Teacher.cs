using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolJournal.Domain
{
    public class Teacher
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ApplicationUser User { get; set; }

        //public int SchoolClassId { get; set; }
        //public SchoolClass SchoolClass { get; set; }
    }
}