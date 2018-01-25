using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJournal.Data.Repositories;
using SchoolJounal.Model;
using SchoolJournal.Models;

namespace SchoolJournal.Servises
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        

        public SubjectService()
        {
            _subjectRepository = new SubjectRepository();
            //_hashidsService = new HashidsService();
        }

        public void AddSubject(SubjectBindingModel model)
        {
            var subject = new Subject
            {
                Name = model.SubjectName
            };

            _subjectRepository.Add(subject);
        }

        public List<SubjectViewModel> GetAllSubjects()
        {
            var subject = _subjectRepository.Get();
            return subject.Select(_ => new SubjectViewModel
            {
                //SubjectNumber = _hashidsSesrvice.Encode(_.Id)
                
            }).ToList();
        }
        public SubjectViewModel GetSubject(string subjectNumber)
        {
            var subjectId = 0;
            //var subjectId = _hashidsService.Decode(subjectNumber);
            var subject = _subjectRepository.Get(subjectId);
            return new SubjectViewModel
            {
                
                SubjectNumber = subjectNumber,
                SubjectName = subject.Name


            };
        }
    }
}