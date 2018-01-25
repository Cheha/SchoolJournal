using System;
﻿using SchoolJournal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Services
{
    interface ISchoolClassService
    {
        List<SchoolClassViewModel> _getAllSchoolClass();
    }
}
