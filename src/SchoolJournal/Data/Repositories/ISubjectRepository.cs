using System.Collections.Generic;
using SchoolJournal.Domain;


namespace SchoolJournal.Data.Repositories
{
    public interface ISubjectRepository
    {
        void Add(Subject subject);
        List<Subject> Get();
        Subject Get(int id);

    }
}
