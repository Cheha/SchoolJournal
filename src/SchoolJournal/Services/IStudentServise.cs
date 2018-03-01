using SchoolJournal.Models;
using System.Collections.Generic;
using SchoolJournal.Domain;

namespace SchoolJournal.Services
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudent(int id);
    }
}