using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJournal.Data.Repository;
using SchoolJournal.Domain;

namespace SchoolJournal.Data.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private ApplicationDbContext _context;
        public TeacherRepository()
        {
            _context = new ApplicationDbContext();
        }

        //Get Teacher
        public Teacher GetTeacher(int Id)
        {
            return _context.Teachers.Find(Id);
        }

        // GetAllTeachers
        public List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        //Create teacher
        public Teacher CreateTeacher(Teacher newTeacher)
        {
            return _context.Teachers.Add(newTeacher);
        }

        //Add class for teacher
        public TeacherSchoolClass AddNewTeacherSchoolClass(SchoolClass newSchoolClass, Teacher thisTeacher)
        {
            return _context.TeacherSchoolClasses.Add(new TeacherSchoolClass() { Teacher = thisTeacher, SchoolClass = newSchoolClass });
        }

        //Add subjects for teacher
        public TeacherSubject AddNewTeacherSubject(Subject newSubject, Teacher teacher)
        {
            return _context.TeacherSubjects.Add(new TeacherSubject() { Teacher = teacher, Subject = newSubject });
        }

        //Get list of teachers subjects
        public List<TeacherSubject> GetListOfTeachersSubjects(int teacherId)
        {
            return _context.TeacherSubjects.Include("Subject").Where(x => x.TeacherId == teacher.Id).ToList();
        }

        //Get list of teachers classes
        public List<TeacherSchoolClass> GetListOfTeacherClasses(int teacherId)
        {
            return _context.TeacherSchoolClasses.Include("SchoolClass").Where(x => x.TeacherId == teacherId).ToList();
        }
    }
}