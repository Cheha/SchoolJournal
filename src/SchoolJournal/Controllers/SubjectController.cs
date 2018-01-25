using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolJournal.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService subjectService;

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
            var subjectViewModel = _subjectSrevice.GetSubject(subjectNumber);
            return View(subjectViewModel);
        }
    }
}