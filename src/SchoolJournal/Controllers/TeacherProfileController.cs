using Microsoft.AspNet.Identity;
using SchoolJournal.Models;
using SchoolJournal.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournal.Controllers
{
    [Authorize(Roles = "teacher")]
    public class TeacherProfileController : Controller
    {
        private readonly TeacherService _teacherService;
        private readonly SchoolClassService _schoolClassService;
        private readonly MarkService _markService;

        public TeacherProfileController()
        {
            _teacherService = new TeacherService();
            _schoolClassService = new SchoolClassService();
            _markService = new MarkService();
        }

        // GET: TeacherProfile
        public async Task<ActionResult> Index()
        {
            string userId = User.Identity.GetUserId();

            if (userId == null)
            {
                return View("Error");
            }

            var model = new TeacherProfileViewModel();

            model.Teacher = await _teacherService.GetTeacherByUserId(userId);
            //TODO model.SchoolClasses = await _teacherService.GetTeachersSchoolClasses(model.Teacher.TeacherId);

            return View(model);
        }

        public ActionResult SchoolClassSubjects(string schoolClassNumber, string teacherId)
        {
            if (string.IsNullOrEmpty(schoolClassNumber))
            {
                return HttpNotFound();
            }

            var result = _schoolClassService.GetSubjectsList(schoolClassNumber);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult TableOfMarks(MarkParamsViewModel markParam)
        {
            var dates = Enumerable
                .Range(0, int.MaxValue)
                .Select(index => markParam.DateFrom.AddDays(index))
                .TakeWhile(date => date <= markParam.DateTill)
                .ToList();

            var students = _schoolClassService.GetStudents(markParam.SchoolClassId);

            var marks = _markService.GetMarks(
                    markParam.DateFrom,
                    markParam.DateTill,
                    markParam.SchoolClassId,
                    markParam.SubjectId
                );

            var model = new TableOfMarksViewModel
            {
                Dates = dates,
                Students = students,
                Marks = marks
            };

            return PartialView("TableOfMarks", model);
        }
    }
}
