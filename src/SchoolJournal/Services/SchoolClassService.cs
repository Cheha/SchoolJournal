using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJournal.Models;
<<<<<<< HEAD
using SchoolJournal.Data.Repository;
=======
using SchoolJournal.Data.Repositories;
>>>>>>> 4929d347b74de476c734a677c60cdcf70b2973f8

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

        public List<SchoolClassViewModel> _getAllSchoolClass()
        {
            var SchoolClassList = _schoolClassRepository.GetSchoolClassList();
            return SchoolClassList.Select(p => new SchoolClassViewModel
            {
                SchoolClassName = p.Name,
                SchoolClassNumber = _hashidsService.Encode(p.Id)
            }).ToList();
        }
    }
}