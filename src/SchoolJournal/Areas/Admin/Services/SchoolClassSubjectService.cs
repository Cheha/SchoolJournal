using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Data.Repositories;
using SchoolJournal.Services;

namespace SchoolJournal.Areas.Admin.Services
{
    public class SchoolClassSubjectService : ISchoolClassSubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly ISchoolClassSubjectRepository _schoolClassSubjectRepository;
        private readonly IHashidService _hashidService;

        public SchoolClassSubjectService()
        {
            _subjectRepository = new SubjectRepository();
            _schoolClassRepository = new SchoolClassRepository();
            _schoolClassSubjectRepository =new SchoolClassSubjectRepository();
            _hashidService = new HashidService();
        }
        
        //Checking entry between SchoolClass and Subject in SchoolClassSubject table
        //Проверка есть ли запись в таблице SchoolClass-И-Subject
        public int CheckEntryBetweenSchoolClassAndSubjectInDataBase(string schoolClassNumber, string SubjectNumber)
        {
            int entryId = _schoolClassSubjectRepository.CheckEntryBetweenSchoolClassAndSubjectInDataBase(_hashidService.Decode(schoolClassNumber), _hashidService.Decode(SubjectNumber));
            if (entryId != 0)
            {
                return entryId;
            }
            else
            {
                return 0;
            }
        }
    }
}
