using SchoolJounal.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJounal.Model;
using SchoolJounal.Data;

namespace SchoolJounal.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppContext _context;

        public SubjectRepository()
        {
            _context = new AppContext();
        }

        public void Create(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public List<Subject> GetAllSubjects()
        {
            return _context.Subjects.ToList();
        }
    }
}
