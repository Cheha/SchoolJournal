using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Data.Repositories;

namespace SchoolJournal.Areas.Admin.Services
{
    public class SchoolClassSubjectService : ISchoolClassSubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ISchoolClassRepository _schoolClassRepository;

        public SchoolClassSubjectService()
        {
            _subjectRepository = new SubjectRepository();
            _schoolClassRepository = new SchoolClassRepository();
        }

        //получить весь список классов по предмету
        //получить весь список предметов по классу
        //получить передмет по классу и названию предметта
        //получить класс по предмету и названию класса

        //редактировать
        //удалить
        //создать

    }
}
