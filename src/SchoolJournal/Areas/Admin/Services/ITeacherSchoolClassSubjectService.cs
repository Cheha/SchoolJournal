using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Domain;
using SchoolJournal.Models;

namespace SchoolJournal.Areas.Admin.Services
{
    public interface ITeacherSchoolClassSubjectService
    {
        Task<TeacherViewModel> GetTeacherBySubjectAndSchoolClass(string subjectNumber, string schoolClassNumber);
        void AddSchoolClassAndSubjectToTeacher(string teacherNumber, string schoolClassNumber, string subjectNumber);
        void RemoveSchoolClassAndSubjectFromTeacher(string teacherNumber, string schoolClassNumber, string subjectNumber);
        Task<int> CheckEntryBetweenTeacherAndSchoolClassSubjectInDataBase(string teacherNumber, string schoolClassNumber, string SubjectNumber);
    }
}
