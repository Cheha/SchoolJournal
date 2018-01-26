using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Domain;

namespace SchoolJournal.Data.Repository
{
    interface ISchoolClassRepository
    {
        void AddSchoolClass(SchoolClass schoolClass);
        List<SchoolClass> GetSchoolClassList();
        List<Student> GetStudentsList(int schoolClassId);
        List<Subject> GetSubjectsList(int schoolClassId);
    }
}
