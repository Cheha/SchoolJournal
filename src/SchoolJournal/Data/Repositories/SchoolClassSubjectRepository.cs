using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Data.Repositories
{
    public class SchoolClassSubjectRepository : ISchoolClassSubjectRepository
    {
        private readonly ApplicationDbContext _context;
        
        public SchoolClassSubjectRepository()
        {
                _context = new ApplicationDbContext();
        }

        public int CheckEntryBetweenSchoolClassAndSubjectInDataBase(int schoolClassId, int SubjectId)
        {
            var resultEntry = _context.SchoolClassSubjects.Where(x => x.SchoolClassId == schoolClassId && x.SubjectId == SubjectId).FirstOrDefault();
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