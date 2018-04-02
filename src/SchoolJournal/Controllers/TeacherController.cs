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

        //[HttpGet]
        //public async Task<ActionResult> ShowTeachersClasses(string teacherId)
        //{
        //    return PartialView(await _teacherService.GetTeachersSchoolClasses(teacherId));
        //}

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> AddTeacher(TeacherBuildModel model)
        {
            if (ModelState.IsValid && model !=null)
            {
                bool result = await _teacherService.AddTeacher(model);
                if (result)
                {
                    return RedirectToAction("ShowAllTeachers");
                }

                else
                {
                    ViewBag.Message("Такой учитель уже есть в Базе");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult UpdateTeacher(string id)
        {
            return View(_teacherService.GetTeacher(id));
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult UpdateTeacher(TeacherViewModel model)
        {
            _teacherService.UpdateTeacher(model);
            return View("ShowAllTeachers");
        }
        
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteTeacher(string  teacherId)
        {
            _teacherService.DeleteTeacher(teacherId);
            return View("ShowAllTeachers");
        }


    }
}