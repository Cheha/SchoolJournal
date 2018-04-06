using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Domain;


namespace SchoolJournal.Data.Repository
{
    interface ITeacherRepository
    {
        Task<Teacher> GetTeacher(int Id);
        Task<List<Teacher>> GetAllTeachers();
        void CreateTeacher(Teacher newTeacher);
        void DeleteTeacher(int id);
        void UpdateTeacher(Teacher model);

        void AddNewTeacherSubject(Subject newSubject, Teacher teacher);

        List<TeacherSubject> GetListOfTeachersSubjects(int teacherId);
        List<TeacherSchoolClassSubject> GetListOfTeacherSchoolClassSubjects(int teacherId);
        List<SchoolClass> GetTeachersSchoolClasses(int teacherId);
        Task<Teacher> GetTeacherByUserId(string userId);
    }
}

