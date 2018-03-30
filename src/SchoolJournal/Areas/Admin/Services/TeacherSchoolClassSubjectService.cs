using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJournal.Data.Repositories;
using SchoolJournal.Domain;
using System.Threading.Tasks;
using SchoolJournal.Areas.Admin.Models;
using SchoolJournal.Services;
using SchoolJournal.Models;

namespace SchoolJournal.Areas.Admin.Services
{
    public class TeacherSchoolClassSubjectService : ITeacherSchoolClassSubjectService
    {
        private readonly ITeacherSchoolClassSubjectRepository _teacherSclClsSubjRepository;
        private readonly IHashidService _hashidsService;
        private readonly ISchoolClassSubjectRepository _schoolClassSubjectRepository;

        public TeacherSchoolClassSubjectService()
        {
            _teacherSclClsSubjRepository = new TeacherSchoolClassSubjectRepository();
            _hashidsService = new HashidService();
            _schoolClassSubjectRepository = new SchoolClassSubjectRepository();
        }

        //Get List of all Teachers SchoolClassSubject
        //получить весь список классов-И-предметов по учителю
        public async Task<List<TeacherSchoolClassSubject>> GetAllTeacherSchoolClassSubjects(string teacherNumber)
        {
            var listResult = await _teacherSclClsSubjRepository.GetListOfTeacherSchoolClassSubjects(_hashidsService.Decode(teacherNumber));
            return listResult;
        }
        //Get Teacher by Class and Subject
        //получить учителя по классу и предмету (не зная id этой связки в таблице-развязке)
        public async Task<TeacherViewModel> GetTeacherBySubjectAndSchoolClass(string subjectNumber, string schoolClassNumber)
        {
            var teacher = await _teacherSclClsSubjRepository.GetTeacherBySubjectAndSchoolClass(_hashidsService.Decode(subjectNumber), _hashidsService.Decode(schoolClassNumber));

            if (teacher != null)
            {
                return new TeacherViewModel { TeacherFirstName=teacher.FirstName, TeacherLastName=teacher.LastName, TeacherId=_hashidsService.Encode(teacher.Id)};
            }
            else
                return null; //TODO - как красиво кинуть ошибку что нет такой связки?
        }
        //Add SchoolClass and Subject to selected Teacher
        //добавить учителю класс-И-предмет
        public async void AddSchoolClassAndSubjectToTeacher(string teacherNumber, string schoolClassNumber, string subjectNumber)
        {
            int isEntryExists = await _teacherSclClsSubjRepository.CheckEntryBetweenTeacherAndSchoolClassSubjectInDataBase(_hashidsService.Decode(teacherNumber), _hashidsService.Decode(schoolClassNumber), _hashidsService.Decode(subjectNumber));
            if (isEntryExists == 0) //such entry between Teacher and SchoolClassSubject doesnt exists
            {
                _teacherSclClsSubjRepository.AddNewEntry(_hashidsService.Decode(teacherNumber), _hashidsService.Decode(schoolClassNumber), _hashidsService.Decode(subjectNumber));

            }
        }
        //Removes entry in tabel TeacherSchoolClassSubject between Teacher and SchoolClassSubject
        public void RemoveSchoolClassAndSubjectFromTeacher(string teacherNumber, string schoolClassNumber, string subjectNumber)
        {
            _teacherSclClsSubjRepository.RemoveConnection(_hashidsService.Decode(teacherNumber), _hashidsService.Decode(schoolClassNumber), _hashidsService.Decode(subjectNumber));
        }

        ////////Сервисные-методы для методов выше
        //
        //Checking entry between SchoolClassSubject and Teacher in TeacherSchoolClassSubject table
        //Проверка есть ли запись в таблице SchoolClassSubject-Teacher
        public async Task<int> CheckEntryBetweenTeacherAndSchoolClassSubjectInDataBase(string teacherNumber, string schoolClassNumber, string SubjectNumber)
        {
            int entryId = await _teacherSclClsSubjRepository.CheckEntryBetweenTeacherAndSchoolClassSubjectInDataBase(_hashidsService.Decode(teacherNumber), _hashidsService.Decode(schoolClassNumber), _hashidsService.Decode(SubjectNumber));
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