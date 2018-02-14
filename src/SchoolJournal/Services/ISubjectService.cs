using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Models;

namespace SchoolJournal.Services
{
    public interface ISubjectService
    {
        List<SubjectViewModel> GetAllSubjects();
        void AddSubject(SubjectBindingModel subject);
        SubjectViewModel GetSubject(string subjectNumber);
    }
}
