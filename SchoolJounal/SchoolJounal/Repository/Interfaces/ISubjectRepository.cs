using SchoolJounal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJounal.Repository.Interfaces
{
    public interface ISubjectRepository
    {
        void Create(Subject subject);
        List<Subject> GetAllSubjects();
    }
}
