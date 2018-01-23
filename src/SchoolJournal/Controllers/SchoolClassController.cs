using SchoolJournal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournal.Controllers
{
    public class SchoolClassController : Controller
    {
        private readonly ISchoolClassService _schoolClassController;

        public SchoolClassController()
        {
            _schoolClassController = new SchoolClassService();
        }

        public ActionResult SchoolClassDetails()
        {
            var scoolClassModel = _schoolClassController._getAllSchoolClass();
            return View(scoolClassModel);

        }
    }
}