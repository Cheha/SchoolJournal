using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult ShowAllTeachers()
        {
            return View(_teacherService.GetAllTeachers());
        }

        [HttpGet]
        public ActionResult ShowTeacher()//(string id)
        {
            return View();// _teacherService.GetTeacher(id));
        }

        [HttpGet]
        public ActionResult ShowTeachersClasses(string teacherId)
        {
            return PartialView(_teacherService.GetTeachersSchoolClasses(teacherId));
        }


    }
}