using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolJournal.Areas.Admin.Models;
using SchoolJournal.Models;

namespace SchoolJournal.Services
{
    public interface ITeacherService
    {
        void Initialize(IValidationDictionary validationDictionary);
        Task<TeacherViewModel> GetTeacher(string teacherId);
        Task<List<TeacherViewModel>> GetAllTeachers();
        Task<bool> IsThisTeacherExists(TeacherCreateViewModel model);
        Task<bool> AddTeacher(TeacherCreateViewModel model);
        bool DeleteTeacher(string teacherId);
        void UpdateTeacher(TeacherViewModel model);
    }
}
