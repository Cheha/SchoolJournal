using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SchoolJournal.Models;
using System.Web.Mvc;
using SchoolJournal.Services;

namespace SchoolJournal.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TeacherService _teacherService;
        public TeacherController()
        {
            _teacherService = new TeacherService();
        }

        [HttpGet]
        public async Task<ActionResult> ShowAllTeachers()
        {
            return View(await _teacherService.GetAllTeachers());
        }

        [HttpGet]
        public async Task<ActionResult> ShowTeacher(string id)
        {
            return View(await _teacherService.GetTeacher(id));
        }
    }
}