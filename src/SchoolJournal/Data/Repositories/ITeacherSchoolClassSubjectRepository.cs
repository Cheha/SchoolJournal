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
        Task<List<TeacherSchoolClassSubject>> GetListOfTeacherSchoolClassSubjects(int teacherId);
        Task<Teacher> GetTeacherBySubjectAndSchoolClass(int subjectId, int schoolClassId);
        Task<int> CheckEntryBetweenTeacherAndSchoolClassSubjectInDataBase(int teacherId, int schoolClassId, int SubjectId);
        void AddNewEntry(int teacherId, int schoolClassId, int subjectId);
    }
}
