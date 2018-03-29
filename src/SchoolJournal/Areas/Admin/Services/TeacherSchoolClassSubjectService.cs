using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJournal.Data.Repositories;

namespace SchoolJournal.Areas.Admin.Services
{
    public class TeacherSchoolClassSubjectService
    {
        //получить весь список классов-И-предметов по учителю
        //получить учителя по классу-И-предмету
        //добавить учителю класс-И-предмет
        //удалить класс-И-предмет у учителя
        //???

        private readonly ITeacherSchoolClassSubjectRepository _teacherSclClsSubjRepository;

        public TeacherSchoolClassSubjectService()
        {
            _teacherSclClsSubjRepository = new TeacherSchoolClassSubjectRepository();
        }

        //Get List of all Teachers SchoolClassSubject
    }
}