using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models
{
    public class MarkViewModel
    {
        public DateTime Date { get; set; }
        public string StudentId { get; set; }
        public string SubjectId { get; set; }
        public string Value { get; set; }
    }
}