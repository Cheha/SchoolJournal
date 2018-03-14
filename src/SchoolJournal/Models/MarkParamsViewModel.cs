using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models
{
    public class MarkParamsViewModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTill { get; set; }
        public string SchoolClassId { get; set; }
        public string SubjectId { get; set; }
    }
}