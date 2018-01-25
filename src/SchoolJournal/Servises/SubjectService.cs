using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Servises
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly IHashidsService hashidsService;

        public SubjectService()
        {
            _subjectRepository = new SubjectRepository();
            _hashidsService = new HashidsService();
        }

        public void AddSubject(SubjectBindinModel model)
        {
            var subject = new Subject
            {
                
            };

            _subjectRepository.Add(subject);
        }

        public List<SubjectViewModel> GetAllSubjects()
        {
            var subject = _subjectRepository.Get();
            return subject.Select(_ => new SubjectViewModel
            {
                SubjectNumber = _hashidsSesrvice.Encode(_.Id)
                
            }).ToList();
        }
        public SubjectViewModel GetSubject(string subjectNumber)
        {
            var subjectId = _hashidsService.Decode(subjectNumber);
            var subject = _subjectRepository.Get(subjectId);
            return new SubjectViewModel
            {
                
                SubjectNumber = subjectNumber

            };
        }
    }
}