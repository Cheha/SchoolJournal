using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Data.Repositories
{
    public interface ISchoolClassSubjectRepository
    {
        int CheckEntryBetweenSchoolClassAndSubjectInDataBase(int schoolClassId, int SubjectId);
    }
}
