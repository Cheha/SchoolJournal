using SchoolJounal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Servises
{
    public interface IStudentServise
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudent(int id);



    }
}