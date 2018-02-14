using SchoolJournal.Data.Repositories;
using System.Collections.Generic;
using SchoolJournal.Domain;

namespace SchoolJournal.Services
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
