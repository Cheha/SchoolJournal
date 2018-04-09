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

        public Mark GetMark(DateTime date, int studentId, int subjectId)
        {
            return _context.Marks
                .Where(m => m.Date == date && m.StudentId == studentId && m.SubjectId == subjectId)
                .FirstOrDefault();
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

        public void Create(Mark mark)
        {
            _context.Marks.Add(mark);
            _context.SaveChanges();
        }

        public void Update(Mark mark)
        {
            _context.Marks.Attach(mark);
            _context.Entry(mark).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Mark mark)
        {
            _context.Marks.Remove(mark);
            _context.SaveChanges();
        }
    }
}