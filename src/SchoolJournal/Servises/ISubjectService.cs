using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.Servises
{
    public interface ISubjectService
    {
        List<SubjectViewModel> GetAllSubjects();
        void AddSubject(SubjectBindinModel subject);
        SubjectViewModel GetSubject(string subjectNumber);
    }
}
