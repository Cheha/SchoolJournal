using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Models
{
    public class TableOfMarksViewModel
    {
        public List<DateTime> Dates { get; set; }
        public List<StudentViewModel> Students { get; set; }
        public List<MarkViewModel> Marks { get; set; }
    }
}