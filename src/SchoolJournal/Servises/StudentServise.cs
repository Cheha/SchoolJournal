using SchoolJounal.Model;
using SchoolJournal.Data.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Servises
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }
        public List<Student> GetAllStudents()
        {
            return  _studentRepository.GetAll();

        }
        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
        }
        public Student GetStudent(int id)
        {
          Student student =  _studentRepository.Get(id);
            
            return student;
        }
    }
}   
