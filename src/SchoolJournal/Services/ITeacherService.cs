using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Models;

namespace SchoolJournal.Services
{
    interface ITeacherService
    {
        TeacherViewModel GetTeacher(string teacherId);
        List<TeacherViewModel> GetTeachers();
        List<SchoolClassViewModel> GetTeachersSchoolClasses(string teacherId);
    }
}
