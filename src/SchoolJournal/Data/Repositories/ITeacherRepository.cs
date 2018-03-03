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
        Teacher GetTeacher(string Id);
        List<Teacher> GetAllTeachers();
        void CreateTeacher(Teacher newTeacher);
        void DeleteTeacher(string id);
        void UpdateTeacher(Teacher model);

        void AddNewTeacherSchoolClass(SchoolClass newSchoolClass, Teacher thisTeacher);
        void AddNewTeacherSubject(Subject newSubject, Teacher teacher);

        List<TeacherSubject> GetListOfTeachersSubjects(string teacherId);
        List<TeacherSchoolClass> GetListOfTeacherClasses(string teacherId);
    }
}

