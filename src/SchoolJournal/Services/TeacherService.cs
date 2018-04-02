using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolJournal.Data.Repository;
using SchoolJournal.Models;
using SchoolJournal.Domain;
using SchoolJournal.Services;


namespace SchoolJournal.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IHashidService _hashids;
        public TeacherService()
        {
            _teacherRepository = new TeacherRepository();
            _hashids = new HashidService();
        }


        // GetTeacher by id
        public async Task<TeacherViewModel> GetTeacher(string teacherId)
        {
            var teacher = await _teacherRepository.GetTeacher(_hashids.Decode(teacherId));
            return new TeacherViewModel() { TeacherId = teacherId, TeacherFirstName = teacher.FirstName, TeacherLastName = teacher.LastName, TeacherFatherName=teacher.FatherName };
        }
        // GetAllTeachers
        public async Task<List<TeacherViewModel>> GetAllTeachers()
        {
            var teachers = await _teacherRepository.GetAllTeachers();
            return teachers.Select(x => new TeacherViewModel() { TeacherId = _hashids.Encode(x.Id), TeacherFirstName = x.FirstName, TeacherLastName = x.LastName }).ToList();
        }
        // Check is Teacher exists using TeacherBuildModel
        public async Task<bool> IsThisTeacherExists(TeacherBuildModel model)
        {
            List<TeacherViewModel> allTeachers = await GetAllTeachers();
            foreach (TeacherViewModel teacher in allTeachers)
            {
                if (teacher.TeacherFirstName == model.TeacherFirstName && teacher.TeacherLastName == model.TeacherLastName && teacher.TeacherFatherName==model.TeacherFatherName)
                {
                    return true;
                }
            }
            return false;
        }
        // Add new Teacher
        public async Task<bool> AddTeacher(TeacherBuildModel model)
        {
            bool result = await IsThisTeacherExists(model);
            if (!result)
            {
                _teacherRepository.CreateTeacher(new Teacher { FirstName = model.TeacherFirstName, LastName = model.TeacherLastName });
                return true;
            }
            else
            {
                return false;
            }
        }
        // Delete Teacher via his id
        public bool DeleteTeacher(string teacherId)
        {
            _teacherRepository.DeleteTeacher(_hashids.Decode(teacherId));

            if (_teacherRepository.GetTeacher(_hashids.Decode(teacherId)) == null)
            {
                return true;
            }
            else
                return false;
        }
        //Update teacher
        public void UpdateTeacher(TeacherViewModel model)
        {
            _teacherRepository.UpdateTeacher(new Teacher
                {
                    FirstName = model.TeacherFirstName,
                    LastName = model.TeacherLastName,
                    Id = _hashids.Decode(model.TeacherId)
                });
        }
        //Get Teacher by userId
        public async Task<TeacherViewModel> GetTeacherByUserId(string userId)
        {
            var teacher = await _teacherRepository.GetTeacherByUserId(userId);

            return new TeacherViewModel
            {
                TeacherId = _hashids.Encode(teacher.Id),
                TeacherFirstName = teacher.FirstName,
                TeacherLastName = teacher.LastName,
                TeacherFatherName = teacher.FatherName
            };
        }
        //Get list of Teacher classes and Subjects
        public List<TeacherSchoolClassSubject> GetListOfTeacherSchoolClassSubjects(string teacherNumber)
        {
            return _teacherRepository.GetListOfTeacherSchoolClassSubjects(_hashids.Decode(teacherNumber));
        }
    }
}