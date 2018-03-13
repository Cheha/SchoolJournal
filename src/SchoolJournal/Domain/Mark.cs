using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Domain
{
    public class Mark
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}