using SchoolJounal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SchoolJournal.Data.repositories
{
    public class StudentRepository : IStudentRepository
    {
        private ApplicationDbContext _context;
        public StudentRepository()
        {
            _context = new ApplicationDbContext();
        }
        public List<Student> Get()
        {
            return _context.Students.ToList();
        }
        public Student GetOne(int id)
        {
           List <Student> students = _context.Students.ToList() ;
            Student student = students.FirstOrDefault(x => x.Id == id);
            return student;
        }
        public void Add(Student stud)
        {
            _context.Students.Add(stud);
            _context.SaveChanges();
        }
    }
}