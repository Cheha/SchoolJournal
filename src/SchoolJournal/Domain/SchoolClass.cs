using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Domain
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TeacherId { get; set; }
    }
}