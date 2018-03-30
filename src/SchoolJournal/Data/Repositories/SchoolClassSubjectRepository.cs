using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJournal.Domain;

namespace SchoolJournal.Data.Repositories
{
    public class SchoolClassSubjectRepository : ISchoolClassSubjectRepository
    {
        private readonly ApplicationDbContext _context;
        
        public SchoolClassSubjectRepository()
        {
                _context = new ApplicationDbContext();
        }

        //Adding new entry between SchoolClass and Subject
        public void AddNewEntry(int schoolClassId, int subjectId)
        {
            _context.SchoolClassSubjects.Add(new SchoolClassSubject
            {
                SchoolClassId = schoolClassId,
                SubjectId = subjectId
            });
            _context.SaveChangesAsync();
        }

        //Removing existing entry between SchoolClass and Subject
        public void RemoveConnection(int schoolClassId, int subjectId)
        {
            var resultId = CheckEntryBetweenSchoolClassAndSubjectInDataBase(schoolClassId, subjectId);
            if (resultId != 0)
            {
                _context.SchoolClassSubjects.Remove(_context.SchoolClassSubjects.Where(x => x.Id==resultId).FirstOrDefault());
                _context.SaveChangesAsync();
            }
        }

        //Checking are exists entry in table SchoolClassSubject between SchoolClass and Subject
        public int CheckEntryBetweenSchoolClassAndSubjectInDataBase(int schoolClassId, int subjectId)
        {
            var resultEntry = _context.SchoolClassSubjects.Where(x => x.SchoolClassId == schoolClassId && x.SubjectId == subjectId).FirstOrDefault();
            if (resultEntry == null)
            {
                return 0;
            }
            else
            {
                return resultEntry.Id;
            }
        }
    }
}