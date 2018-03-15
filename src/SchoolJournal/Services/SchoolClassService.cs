using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJournal.Models;
using SchoolJournal.Data.Repositories;

namespace SchoolJournal.Services
{
    public class SchoolClassService : ISchoolClassService
    {
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly IHashidsService _hashidsService;

        public SchoolClassService()
        {
            _schoolClassRepository = new SchoolClassRepository();
            _hashidsService = new HashidService();
        }

        public List<SchoolClassViewModel> GetAllSchoolClass()
        {
            var SchoolClassList = _schoolClassRepository.GetSchoolClassList();
            return SchoolClassList.Select(p => new SchoolClassViewModel
            {
                SchoolClassName = p.Name,
                SchoolClassNumber = _hashidsService.Encode(p.Id)
            }).ToList();
        }

        public List<StudentViewModel> GetStudents(string schoolClassId)
        {
            var students = _schoolClassRepository.GetStudentsList(_hashidsService.Decode(schoolClassId));

            return students.Select(s => new StudentViewModel
            {
                StudentId = _hashidsService.Encode(s.Id),
                StudentFirstName = s.FirstName,
                StudentLastName = s.LastName,
                SchoolClassId = _hashidsService.Encode(s.SchoolClassId)
            }).ToList();
        }

        public List<SubjectViewModel> GetSubjectsList(string schoolClassId)
        {
            var subjects = _schoolClassRepository.GetSubjectsList(_hashidsService.Decode(schoolClassId));

            return subjects.Select(s => new SubjectViewModel {
                SubjectNumber = _hashidsService.Encode(s.Id),
                SubjectName = s.Name
            }).ToList();
        }
    }
}