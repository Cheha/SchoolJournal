using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Domain
{
    public class SchoolClassSubject
    {
        public int Id { get; set; }

        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
