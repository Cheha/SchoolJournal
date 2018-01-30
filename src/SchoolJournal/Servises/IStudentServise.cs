using SchoolJounal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Servises
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudent(int id);
    }
}