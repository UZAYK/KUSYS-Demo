using Microsoft.AspNetCore.Mvc;

using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Business.Interfaces;

namespace KUSYSDemo.Controllers
{
    public class StudentCourseMapController : Controller
    {
        #region CTOR - DEPENDENCY INJECTION

        private readonly IStudentCourseMapService _studentCourseMapService;
        private readonly IStudentService _studentService;

        public StudentCourseMapController(IStudentCourseMapService studentCourseMapService, IStudentService studentService, ICourseService courseService)
        {
            _studentCourseMapService = studentCourseMapService;
            _studentService = studentService;
        }
        #endregion

        public IActionResult Index()
        {
            return View(_studentCourseMapService.GetMapAll());
        }

        public ActionResult GetMap(int id)
        {
            return Json(_studentCourseMapService.GetByMap(id));
        }

        public IActionResult Create()
        {
            return View(_studentCourseMapService.GetStudentAndCourseMap());
        }

        [HttpPost]
        public IActionResult Create(StudentCourseMap model)
        {
            if (ModelState.IsValid)
            {
                // Checking whether a student is enrolled in the same course is done here.
                if (_studentCourseMapService.CourseValidation(model.StudentId, model.CourseId))
                {
                    _studentCourseMapService.Add(model);
                    TempData["result"] = "Registration Successful!";

                    return RedirectToAction("Create");
                }
                else
                {
                    // View status message is returned according to status.
                    TempData["result"] = "This student has already taken this course!";
                }
            }
            return RedirectToAction("Create");
        }

        public IActionResult Delete(int id)
        {
            _studentCourseMapService.Remove(_studentCourseMapService.GetById(id));
            return RedirectToAction("Index");
        }

    }
}
