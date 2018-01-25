using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJounal.Model;

namespace SchoolJournal.Data.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRepository()
        {
            _context = new ApplicationDbContext();
        }
        public void Add(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }
        public List<Subject> Get()
        {
            return _context.Subjects
                .ToList();
        }
        public Subject Get(int id)
        {
            return _context.Subjects
                .FirstOrDefault(_ => _.Id == id);
        }
    }
}