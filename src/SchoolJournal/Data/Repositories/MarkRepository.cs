using SchoolJournal.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolJournal.Data.Repositories
{
    public class MarkRepository
    {
        private readonly ApplicationDbContext _context;

        public MarkRepository()
        {
            _context = new ApplicationDbContext();
        }

        public List<Mark> GetMarks(DateTime dateFrom, DateTime dateTill, int schoolClassId, int subjectId)
        {
            return _context.Marks
                .Include(m => m.Student)
                .Where(m => m.SubjectId == subjectId)
                .Where(m => m.Date >= dateFrom && m.Date <= dateTill)
                .Where(m => m.Student.SchoolClassId == schoolClassId)
                .ToList();
        }
    }
}