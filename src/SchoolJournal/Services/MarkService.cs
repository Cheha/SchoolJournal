using SchoolJournal.Data.Repositories;
using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Services
{
    public class MarkService
    {
        private readonly MarkRepository _markRepository;
        private readonly HashidService _hashidService;

        public MarkService()
        {
            _markRepository = new MarkRepository();
            _hashidService = new HashidService();
        }

        public List<MarkViewModel> GetMarks(DateTime dateFrom, DateTime dateTill, string schoolClassId, string subjectId)
        {
            return _markRepository.GetMarks(
                dateFrom,
                dateTill,
                _hashidService.Decode(schoolClassId),
                _hashidService.Decode(subjectId)
            )
            .Select(m => new MarkViewModel {
                Date = m.Date,
                StudentId = _hashidService.Encode(m.StudentId),
                SubjectId = _hashidService.Encode(m.SubjectId),
                Value = m.Value.ToString()
            }).ToList();
        }
    }
}