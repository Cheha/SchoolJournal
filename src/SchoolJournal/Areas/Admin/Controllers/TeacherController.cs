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

        //TODO
        //////ПО ФАКТУ ТУТ ЕЩЁ СОЗДАЁТСЯ ПОЛЬЗОВАТЕЛЬ И БЫЛО Б НЕПЛОХО ЕГО СОЗДАТЬ В USER-СЕРВИСАХ
        ////////Add Teacher to DB
        //////[HttpPost]
        //////public ActionResult AddTeacher(TeacherBuildModel model)
        //////{
        //////    if (ModelState.IsValid)
        //////    {
        //////        _teacherService.AddTeacher(model);
        //////    }
        //////    return RedirectToAction("AllTeachers");
        //////}

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
    }
}