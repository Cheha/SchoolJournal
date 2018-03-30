using AutoMapper;
using SchoolJournal.Data.Repositories;
using SchoolJournal.Domain;
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
            var markList = _markRepository.GetMarks(
                dateFrom,
                dateTill,
                _hashidService.Decode(schoolClassId),
                _hashidService.Decode(subjectId)
            );

            return Mapper.Map<List<Mark>, List<MarkViewModel>>(markList);
        }

        public void SetMark(MarkPostViewModel model)
        {
            var mark = Mapper.Map<MarkPostViewModel, Mark>(model);

            var foundedMark = _markRepository.GetMark(mark.Date, mark.StudentId, mark.SubjectId);

            if (foundedMark == null)
            {
                if (mark.Value != 0)
                {
                    _markRepository.Create(mark);
                }
            }
            else
            {
                if (mark.Value == 0)
                {
                    _markRepository.Remove(foundedMark);
                }
                else
                {
                    foundedMark.Value = mark.Value;
                    _markRepository.Update(foundedMark);
                }
            }
        }
    }
}