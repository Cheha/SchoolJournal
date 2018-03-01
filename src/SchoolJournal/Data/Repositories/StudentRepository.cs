using SchoolJournal.Domain;
using SchoolJournal.Data.Repositories;
using System.Collections.Generic;
using System.Linq;


namespace SchoolJournal.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private ApplicationDbContext _context;
        public StudentRepository()
        {
            _context = new ApplicationDbContext();
        }
        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }
        public Student Get(int id)
        {
            Student student = _context.Students.FirstOrDefault(x => x.Id == id);
            return student;
        }
        public void Add(Student stud)
        {
            _context.Students.Add(stud);
            _context.SaveChanges();
        }
    }
}