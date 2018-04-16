using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolJournal.Services;
using SchoolJournal.Areas.Admin.Services;
using SchoolJournal.Models;
using SchoolJournal.Areas.Admin.Models;
using System.Threading.Tasks;
using System.Net;

namespace SchoolJournal.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ITeacherSchoolClassSubjectService _teacherSclClsSubjService;
        private readonly ISchoolClassSubjectService _schoolClsSubjService;

        public TeacherController()
        {
            _teacherService = new TeacherService();
            _teacherService.Initialize(new ModelStateWrapper(this.ModelState));
            _teacherSclClsSubjService = new TeacherSchoolClassSubjectService();
            _schoolClsSubjService = new SchoolClassSubjectService();
        }

        //Get List of all Teachers in DB
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = await _teacherService.GetAllTeachers();
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Details(string id)
        {
            return View(await _teacherSclClsSubjService.TeacherDetails(id));
        }

        ////////////////////////////////////////////////
        //Get Teacher by Id
        [HttpGet]
        public ActionResult GetTeacherById(string teacherNumber)
        {
            return PartialView(_teacherService.GetTeacher(teacherNumber));
        }

        //Update Teacher
        [HttpPost]
        public ActionResult UpdateTeacher(TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                _teacherService.UpdateTeacher(model);
            }
            return RedirectToAction("AllTeachers");
        }

        //Add to a Teacher SchoolClass-And-Subject
        [HttpPost]
        public ActionResult AddSchoolClassSubjectToTeacher(string teacherNumber, string schoolClassNumber, string subjectNumber)
        {
            _teacherSclClsSubjService.AddSchoolClassAndSubjectToTeacher(teacherNumber, schoolClassNumber, subjectNumber);
            return RedirectToAction("TeacherDetails");
        }

        //Delete SchoolClassSubject from a Teacher
        [HttpGet]
        public ActionResult DeleteSchoolClassSubjectFromTeacher(string teacherNumber, string schoolClassNumber, string subjectNumber)
        {
            _teacherSclClsSubjService.RemoveSchoolClassAndSubjectFromTeacher(teacherNumber, schoolClassNumber, subjectNumber);
            return RedirectToAction("TeacherDetails");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(TeacherCreateViewModel model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Password != model.PasswordConfirm)
            {
                ModelState.AddModelError("PasswordConfirm", "Пароль и подтверждение пароля не совпадают.");
                return View(model);
            }

            var teacherAdded = await _teacherService.AddTeacher(model);

            if (!teacherAdded)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}