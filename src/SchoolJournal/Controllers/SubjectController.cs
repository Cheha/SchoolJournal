using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolJournal.Servises;
using SchoolJounal.Model;
using SchoolJournal.Models;

namespace SchoolJournal.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectController()
        {
           _subjectService = new SubjectService();
        }

        public ActionResult Index()
        {
            var subjects = _subjectService.GetAllSubjects();
            return View(subjects);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SubjectBindingModel subject)
        {
            _subjectService.AddSubject(subject);
            return RedirectToAction("Index");
        }
        public ActionResult Details(string subjectNumber)
        {
            var subjectViewModel = _subjectService.GetSubject(subjectNumber);
            return View(subjectViewModel);
        }
    }
}