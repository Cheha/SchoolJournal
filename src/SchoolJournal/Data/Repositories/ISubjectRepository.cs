using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJounal.Model;
namespace SchoolJournal.Data.Repositories
{
    public interface ISubjectRepository
    {
        void Add(Subject subject);
        List<Subject> Get();
        Subject Get(int id);

    }
}
