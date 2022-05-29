using AutoMapper;
using KUSYSDemo.Business.Interfaces;
using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;
using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Models;
using KUSYSDemo.Models.StudentCourseMap;
using Microsoft.AspNetCore.Mvc;

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
                if (_studentCourseMapService.CourseValidation(model.StudentId, model.CourseId))
                {
                    _studentCourseMapService.Add(model);

                    return RedirectToAction("Index");
                }
            }
            else
            {
                //zaten bir kayıt var
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _studentCourseMapService.Remove(_studentCourseMapService.GetById(id));
            //Toast("Deletion successful", Core.Concrete.Toastr.ToastrType.Success);
            return RedirectToAction("Index");
        }

    }
}
