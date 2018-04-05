using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Areas.Admin.Services
{
    public interface ISchoolClassSubjectService
    {
        int CheckEntryBetweenSchoolClassAndSubjectInDataBase(string schoolClassNumber, string SubjectNumber);

    }
}
