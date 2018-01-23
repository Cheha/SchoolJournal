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
        Teacher GetTeacher(int Id);
        List<Teacher> GetAllTeachers();
        Teacher CreateTeacher(Teacher newTeacher);

        TeacherSchoolClass AddNewTeacherSchoolClass(SchoolClass newSchoolClass, Teacher thisTeacher);
        TeacherSubject AddNewTeacherSubject(Subject newSubject, Teacher teacher);

        List<TeacherSubject> GetListOfTeachersSubjects(Teacher teacher);
        List<TeacherSchoolClass> GetListOfTeacherClasses(Teacher teacher);
    }
}
