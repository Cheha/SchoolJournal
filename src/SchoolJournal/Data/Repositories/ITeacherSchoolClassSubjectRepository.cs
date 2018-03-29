using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Domain;

namespace SchoolJournal.Data.Repositories
{
    public interface ITeacherSchoolClassSubjectRepository
    {
        List<TeacherSchoolClassSubject> GetListOfTeacherSchoolClassSubjects(int teacherId);
    }
}
