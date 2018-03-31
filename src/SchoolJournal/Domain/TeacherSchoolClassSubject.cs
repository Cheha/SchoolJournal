using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Domain
{
    public class TeacherSchoolClassSubject
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int SchoolClassSubjectId { get; set; }
        public SchoolClassSubject SchoolClassSubject { get; set; }
    }
}