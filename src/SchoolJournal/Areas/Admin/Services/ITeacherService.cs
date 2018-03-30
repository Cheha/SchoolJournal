using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Areas.Admin.Models;

namespace SchoolJournal.Areas.Admin.Services
{
    public interface ITeacherService
    {
            Task<TeacherViewModel> GetTeacher(string teacherId);
            Task<List<TeacherViewModel>> GetAllTeachers();
            //List<SchoolClassViewModel> GetTeachersSchoolClasses(string teacherId);
            Task<bool> IsThisTeacherExists(TeacherBuildModel model);
            Task<bool> AddTeacher(TeacherBuildModel model);
            bool DeleteTeacher(string teacherId);
            Task UpdateTeacher(TeacherViewModel model);
    }
}
