﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Domain
{
    public class TeacherSubject
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
