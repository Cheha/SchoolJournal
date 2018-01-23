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
        // GET: Teacher   Teacher GetTeacher(int Id);
        //1   List<TeacherSchoolClass> GetListOfTeacherClasses(Teacher teacher);
        //2

        
        public ActionResult ShowTeacher(string id)
        {
            return View();
        }

    }
}