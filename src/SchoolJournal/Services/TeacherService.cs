using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJournal.Data.Repository;
using SchoolJournal.Models;

namespace SchoolJournal.Services
{
    public class TeacherService
    {
        private readonly TeacherRepository _teacherRepository;
        private readonly SchoolClassRepository _schoolClassRepository;
        private readonly Hashids _hashids;
        public TeacherService()
        {
            _schoolClassRepository = new SchoolClassRepository();
            _teacherRepository = new TeacherRepository();
            _hashids = new Hashids();
        }


        //1 GetTeacher
        public TeacherViewModel GetTeacher(string teacherId)
        {
            var temp = _teacherRepository.GetTeacher(_hashids.Decode(teacherId));
            return new TeacherViewModel() { TeacherId = teacherId, TeacherFirstName = temp.FirstName, TeacherLastName = temp.LastName };
        }
        //1.1 GetAllTeachers
        public List<TeacherViewModel> GetAllTeachers()
        {
            var temp = _teacherRepository.GetAllTeachers();
            return temp.Select(x => new TeacherViewModel() { TeacherId = _hashids.Encode(x.Id), TeacherFirstName = x.FirstName, TeacherLastName = x.LastName }).ToList();
        }
        //2   List<TeacherSchoolClass> GetListOfTeacherClasses(Teacher teacher);
        public List<SchoolClassViewModel> GetTeachersSchoolClasses(string teacherId)
        {
            var temp = _schoolClassRepository.GetAllSchoolClasses();
            return temp.Select(x => new SchoolClassViewModel() {ClassName=x.ClassName,ClassId=_hashids.Decode(x.id)}).ToList();
        }

    }
}