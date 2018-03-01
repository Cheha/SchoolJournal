using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournal.Controllers
{
    public class TeacherProfileController : Controller
    {
        // GET: TeacherProfile
        public ActionResult Index() //int teacherId
        {
            return View();
        }
    }
}
