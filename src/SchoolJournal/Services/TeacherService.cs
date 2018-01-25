using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolJournal.Data.Repository;
using SchoolJournal.Models;
using HashidsNet;

namespace SchoolJournal.Services
{
    public class TeacherService
    {
        private readonly TeacherRepository _teacherRepository;
        //private readonly SchoolClassRepository _schoolClassRepository;
        private readonly HashidService _hashids;
        public TeacherService()
        {
            //_schoolClassRepository = new SchoolClassRepository();
            _teacherRepository = new TeacherRepository();
            _hashids = new HashidService();
        }


        //1 GetTeacher by id
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
        //2  GetListOfTeacherClasses by Teacher id
        public List<SchoolClassViewModel> GetTeachersSchoolClasses(string teacherId)
        {
            var temp = _teacherRepository.GetListOfTeacherClasses(_hashids.Decode(teacherId));

            return temp.Select(x => new SchoolClassViewModel()
            {
                SchoolClassName = x.SchoolClass.Name,
                SchoolClassNumber = _hashids.Encode(x.SchoolClass.Id)
            }).ToList();
        }

    }
}