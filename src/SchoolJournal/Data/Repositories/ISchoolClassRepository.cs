using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Data;
using SchoolJournal.Domain;

namespace SchoolJournal.Data.Repositories
{
    public interface ISchoolClassRepository
    {
        void AddSchoolClass(SchoolClass schoolClass);
        List<SchoolClass> GetSchoolClassList();
        List<Student> GetStudentsList(int schoolClassId);
        List<Subject> GetSubjectsList(int schoolClassId);
    }
}
