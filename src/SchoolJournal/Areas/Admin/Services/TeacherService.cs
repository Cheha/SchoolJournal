﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolJournal.Data.Repository;
using SchoolJournal.Areas.Admin.Models;
using SchoolJournal.Areas.Admin.Services;
using SchoolJournal.Domain;
using HashidsNet;

namespace SchoolJournal.Areas.Admin.Services
{
    public class TeacherService : ITeacherService
    {
            private readonly ITeacherRepository _teacherRepository;
            //private readonly SchoolClassRepository _schoolClassRepository;
            private readonly IHashidService _hashids;
            public TeacherService()
            {
                //_schoolClassRepository = new SchoolClassRepository();
                _teacherRepository = new TeacherRepository();
                _hashids = new HashidService();
            }


            //1 GetTeacher by id
            public async Task<TeacherViewModel> GetTeacher(string teacherId)
            {
                var teacher = await _teacherRepository.GetTeacher(_hashids.Decode(teacherId));
                return new TeacherViewModel() { TeacherId = teacherId, TeacherFirstName = teacher.FirstName, TeacherLastName = teacher.LastName };
            }
            //1.1 GetAllTeachers
            public async Task<List<TeacherViewModel>> GetAllTeachers()
            {
                var teachers = await _teacherRepository.GetAllTeachers();
                return teachers.Select(x => new TeacherViewModel() { TeacherId = _hashids.Encode(x.Id), TeacherFirstName = x.FirstName, TeacherLastName = x.LastName }).ToList();
            }
            //2  GetListOfTeacherClasses by Teacher id
            //public async Task<List<SchoolClassViewModel>> GetTeachersSchoolClasses(string teacherId)
            //{
            //    var teacherShoolClasses = _teacherRepository.GetListOfTeacherClasses(_hashids.Decode(teacherId));

            //    return teacherShoolClasses.Select(x => new SchoolClassViewModel()
            //    {
            //        SchoolClassName = x.SchoolClass.Name,
            //        SchoolClassNumber = _hashids.Encode(x.SchoolClass.Id)
            //    }).ToList();
            //}
            //3 Check is Teacher exists using TeacherBuildModel
            public async Task<bool> IsThisTeacherExists(TeacherBuildModel model)
            {
                List<TeacherViewModel> allTeachers = await GetAllTeachers();
                foreach (TeacherViewModel teacher in allTeachers)
                {
                    if (teacher.TeacherFirstName == model.TeacherFirstName && teacher.TeacherLastName == model.TeacherLastName)
                    {
                        return true;
                    }
                }
                return false;
            }
            //4 Add new Teacher
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
            //5 Delete Teacher via his id
            public async Task<bool> DeleteTeacher(string teacherId)
            {
                await _teacherRepository.DeleteTeacher(_hashids.Decode(teacherId));

                if (_teacherRepository.GetTeacher(_hashids.Decode(teacherId)) == null)
                {
                    return true;
                }
                else
                    return false;
            }
            //Update teacher
            public async Task UpdateTeacher(TeacherViewModel model)
            {
                await Task.Run(() =>
                {
                    _teacherRepository.UpdateTeacher(new Teacher
                    {
                        FirstName = model.TeacherFirstName,
                        LastName = model.TeacherLastName,
                        Id = _hashids.Decode(model.TeacherId)
                    });
                });
            }

            public async Task<TeacherViewModel> GetTeacherByUserId(string userId)
            {
                var teacher = await _teacherRepository.GetTeacherByUserId(userId);

                return new TeacherViewModel
                {
                    TeacherId = _hashids.Encode(teacher.Id),
                    TeacherFirstName = teacher.FirstName,
                    TeacherLastName = teacher.LastName
                };
            }
    }
}