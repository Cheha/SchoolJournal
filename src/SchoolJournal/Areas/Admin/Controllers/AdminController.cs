using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Security.Authentication;
using SchoolJournal.Services;
using SchoolJournal.Areas.Admin.Services;
using SchoolJournal.Models;
using SchoolJournal.Areas.Admin.Models;

namespace SchoolJournal.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ITeacherSchoolClassSubjectService _teacherSclClsSubjService;
        private readonly ISchoolClassSubjectService _schoolClsSubjService;

        public AdminController()
        {
            _teacherService = new TeacherService();
            _teacherSclClsSubjService = new TeacherSchoolClassSubjectService();
            _schoolClsSubjService = new SchoolClassSubjectService();
        }


        // Basic Admin page
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //Get List of all Teachers in DB
        [HttpGet]
        public ActionResult AllTeachers()
        {
            return PartialView(_teacherService.GetAllTeachers());
        }
        //Get Teacher by Id
        [HttpGet]
        public ActionResult GetTeacherById(string teacherNumber)
        {
            return PartialView(_teacherService.GetTeacher(teacherNumber));
        }
        //Add Teacher to DB
        [HttpPost]
        public ActionResult AddTeacher(TeacherBuildModel model)
        {
            if (ModelState.IsValid)
            {
                _teacherService.AddTeacher(model);
            }
            return RedirectToAction("AllTeachers");
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
        ////
        ////Get list of Teacher SchoolClasses-And-Subjects
        //[HttpGet]
        //public ActionResult TeacherDetails(string teacherNumber)
        //{
        //    _teacherService.
        //}
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