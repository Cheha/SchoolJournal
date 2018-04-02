using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Models;

namespace SchoolJournal.Services
{
    public interface ITeacherService
    {
        Task<TeacherViewModel> GetTeacher(string teacherId);
        Task<List<TeacherViewModel>> GetAllTeachers();
        Task<bool> IsThisTeacherExists(TeacherBuildModel model);
        Task<bool> AddTeacher(TeacherBuildModel model);
        bool DeleteTeacher(string teacherId);
        void UpdateTeacher(TeacherViewModel model);
    }
}
