using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolJournal.Data.Repository;
using SchoolJournal.Models;
using SchoolJournal.Domain;
using SchoolJournal.Services;
using AutoMapper;
using SchoolJournal.Areas.Admin.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolJournal.Data;

namespace SchoolJournal.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IHashidService _hashids;
        private readonly ApplicationUserManager _userManager;
        private IValidationDictionary _validatonDictionary;

        public TeacherService()
        {
            _teacherRepository = new TeacherRepository();
            _hashids = new HashidService();
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }

        public void Initialize(IValidationDictionary validationDictionary)
        {
            _validatonDictionary = validationDictionary;
        }

        // GetTeacher by id
        public async Task<TeacherViewModel> GetTeacher(string teacherId)
        {
            var teacher = await _teacherRepository.GetTeacher(_hashids.Decode(teacherId));
            return new TeacherViewModel() { TeacherId = teacherId.ToString(), TeacherFirstName = teacher.FirstName, TeacherLastName = teacher.LastName, TeacherFatherName=teacher.FatherName };
        }
        // GetAllTeachers
        public async Task<List<TeacherViewModel>> GetAllTeachers()
        {
            var teachers = await _teacherRepository.GetAllTeachers();
            return teachers.Select(x => new TeacherViewModel() { TeacherId = _hashids.Encode(x.Id), TeacherFirstName = x.FirstName, TeacherLastName = x.LastName, TeacherFatherName = x.FatherName }).ToList();
        }
        // Check is Teacher exists using TeacherBuildModel
        public async Task<bool> IsThisTeacherExists(TeacherCreateViewModel model)
        {
            List<TeacherViewModel> allTeachers = await GetAllTeachers();
            foreach (TeacherViewModel teacher in allTeachers)
            {
                if (teacher.TeacherFirstName == model.FirstName && teacher.TeacherLastName == model.LastName && teacher.TeacherFatherName==model.FatherName)
                {
                    return true;
                }
            }
            return false;
        }
        // Add new Teacher
        public async Task<bool> AddTeacher(TeacherCreateViewModel model)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser != null)
            {
                _validatonDictionary.AddError("Email", "Пользователь с таким e-mail уже существует.");
            }

            bool teacherExist = await IsThisTeacherExists(model);

            if (teacherExist)
            {
                _validatonDictionary.AddError("", "Учитель с таким ФИО уже существует.");
            }

            if (_validatonDictionary.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    foreach (string errorMessage in result.Errors)
                    {
                        _validatonDictionary.AddError("Error", errorMessage);
                    }
                    return false;
                }

                var teacher = Mapper.Map<Teacher>(model);
                teacher.UserId = user.Id;

                _teacherRepository.CreateTeacher(teacher);
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

        public List<SchoolJournal.Models.SchoolClassViewModel> GetTeachersSchoolClasses(string teacherNumber)
        {
            var result = _teacherRepository.GetTeachersSchoolClasses(_hashids.Decode(teacherNumber));

            return result.Select(sc => new SchoolJournal.Models.SchoolClassViewModel {
                SchoolClassNumber = _hashids.Encode(sc.Id),
                SchoolClassName = sc.Name
            })
            .ToList();
        }
    }
}