using AutoMapper;
using KUSYSDemo.Business.Interfaces;
using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace KUSYSDemo.Controllers
{
    public class StudentController : Controller
    {
        #region CTOR - DEPENDENCY INJECTION

        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, ICourseService _courseService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        public ActionResult Index()
        {
            return View(_mapper.Map<List<StudentModel>>(_studentService.GetAll()));
        }

        public IActionResult Create()
        {
            return View(new StudentModel());
        }

        [HttpPost]
        public IActionResult Create(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                _studentService.Add(new Student
                {
                    BirthDate = model.BirthDate,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                });
                return RedirectToAction("Index");
            }
            //info 
            return View("Index");
        }
    }
}
