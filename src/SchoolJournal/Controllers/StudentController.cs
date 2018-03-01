using SchoolJournal.Services;
using System.Web.Mvc;

namespace SchoolJournal.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }
        public ActionResult Index()
        {
            var students = _studentService.GetAllStudents();
            return View(students);
        }

    }
}