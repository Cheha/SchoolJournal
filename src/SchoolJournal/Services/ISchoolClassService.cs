using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Services
{
    interface ISchoolClassService
    {
        List<SchoolClassViewModel> GetAllSchoolClass();
        List<StudentViewModel> GetStudents(string schoolClassId);
        List<SubjectViewModel> GetSubjectsList(string schoolClassId);

    }
}
