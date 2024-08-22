using FinalExercise.Data;
using FinalExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalExercise.Controllers
{
    public class QuestionController : Controller
    {
        private readonly SchoolContext _context;

        public QuestionController(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Programmes.Include(p => p.Courses).ThenInclude(c => c.Enrollments).ToList();
            return View(data);
        }

        public IActionResult Course(int courseid)
        {
            var result = _context.Courses.Include(c => c.Enrollments)
                .ThenInclude(e => e.Student).Single(c => c.CourseId == courseid);

            return View(result);
        }

        public IActionResult UpdateEnrollment(int id)
        {
            UpdateEnrollmentViewModel vm = new UpdateEnrollmentViewModel();

            string courseName = _context.Enrollments
                .Include(e => e.Course).Single(e => e.EnrollmentId == id).Course.Name;

            var studentList = new SelectList(
                _context.Students, 
                "StudentId",
                "FullName"
                );

            var enrollment = _context.Enrollments.Find(id);

            vm.CourseName = courseName;
            vm.StudentList = studentList;
            vm.Enrollment = enrollment;
            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdateEnrollment(UpdateEnrollmentViewModel model)
        {
            _context.Update(model.Enrollment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
