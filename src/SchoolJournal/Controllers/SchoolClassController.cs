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
        private readonly ISchoolClassService _schoolClassService;

        public SchoolClassController()
        {
            _schoolClassService = new SchoolClassService();
        }

        public ActionResult SchoolClassList()
        {
            var scoolClassModel = _schoolClassService._getAllSchoolClass();
            return View(scoolClassModel);

        }
    }
}