using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Data.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext context;

        public SubjectRepository()
        {
            _context = new AppDbContext();
        }
        public void Add(Subject subject)
        {
            _context.Add.Subject(subject);
            _context.SaveChanges();
        }
        public List<Subject> Get()
        {
            return _context.Subject
                .ToList();
        }
        public Subject Get(int id)
        {
            return _context.Subject
                .FirstOrDefault(_ => _.Id == id);
        }
    }
}