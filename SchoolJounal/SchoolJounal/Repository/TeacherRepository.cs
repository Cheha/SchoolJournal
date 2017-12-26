using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJounal.Model;
using SchoolJounal.Data;

//Create teacher
//Add class for teacher
//Add subjects for teacher
//Get list of teachers subjects
//Get list of teachers classes

namespace SchoolJounal.Repository
{

    public class TeacherRepository : ITeacherRepository
    {
        private AppContext _context;

        public TeacherRepository()
        {
            _context = new AppContext();
        }

        public Teacher GetTeacher(int Id)
        {
            return _context.Teachers.Find(Id);
        }

        //Create teacher
        public Teacher CreateTeacher(Teacher newTeacher)
        {
            return _context.Teachers.Add(newTeacher);
        }

        //Add class for teacher
        public TeacherSchoolClass AddNewTeacherSchoolClass(SchoolClass newSchoolClass, Teacher thisTeacher)
        {
            return _context.TeacherSchoolClasses.Add(new TeacherSchoolClass() { Teacher = thisTeacher, SchoolClass = newSchoolClass}); 
        }

        //Add subjects for teacher
        public TeacherSubject AddNewTeacherSubject(Subject newSubject, Teacher teacher)
        {
            return _context.TeacherSubjects.Add(new TeacherSubject() {Teacher=teacher,Subject=newSubject });
        }

        //Get list of teachers subjects
        public List<TeacherSubject> GetListOfTeachersSubjects(Teacher teacher)
        {
            return _context.TeacherSubjects.Where(x => x.TeacherId == teacher.Id).ToList();
        }

        //Get list of teachers classes
        public List<TeacherSchoolClass> GetListOfTeacherClasses(Teacher teacher)
        {
            return _context.TeacherSchoolClasses.Where(x=>x.TeacherId==teacher.Id).ToList();
        }
    }
}
