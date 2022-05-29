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
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public StudentCourseMapController(IStudentCourseMapService studentCourseMapService,
        IMapper mapper, IStudentService studentService, ICourseService courseService)
        {
            _studentCourseMapService = studentCourseMapService;
            _studentService = studentService;
            _courseService = courseService;
            _mapper = mapper;
        }
        #endregion

        public IActionResult Index()
        {
            //var data = _courseService.GetAll().Join(_studentService.GetAll(),
            //student => student.CourseId,
            //course => course.CourseId,
            //(stud, cour) => new { Student = stud, Course = cour }).ToList();

           

            return View(/*_mapper.Map<List<StudentModel>>(query.ToList())*/_studentCourseMapService.GetMapAll());
        }

        public IActionResult Create()
        {
            // create the method of this operation
            var students = _studentCourseMapService.GetStudentAll().ToList();
            var course = _studentCourseMapService.GetCourseAll().ToList();

            return View(new StudentCourseMapListModel
            {
                CourseName = course,
                StudentName = students,
            });
        }

        [HttpPost]
        public IActionResult Create(StudentCourseMapAddModel model)
        {
            if (ModelState.IsValid)
            {
                // a hasvalue method will be written here
                var item = _studentService.Find(s => s.Id == model.Id && s.CourseId != 0 && s.CourseId != model.CourseId).FirstOrDefault();
                if (item == null)
                {
                    //var newModel = _mapper.Map(model, _studentService.GetById(model.Id));
                    _studentService.Update(model, _studentService.GetById(model.Id));

                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

    }
}
