using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Data.Repositories
{
    public interface ISchoolClassSubjectRepository
    {
        void AddNewEntry(int schoolClassId, int subjectId);
        void RemoveConnection(int schoolClassId, int subjectId);
        int CheckEntryBetweenSchoolClassAndSubjectInDataBase(int schoolClassId, int SubjectId);
    }
}
