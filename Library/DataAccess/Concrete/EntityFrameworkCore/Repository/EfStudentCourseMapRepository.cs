using AutoMapper;
using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;
using KUSYSDemo.DataAccess.Interfaces;
using KUSYSDemo.Models;
using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Models.StudentCourseMap;

namespace KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Repository
{
    public class EfStudentCourseMapRepository : EfGenericRepository<StudentCourseMap>, IStudentCourseMapDal
    {
        private readonly KusysDemoContext _context;
        private readonly IMapper _mapper;
        public EfStudentCourseMapRepository(KusysDemoContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Course> GetCourseAll()
        => _context.Set<Course>().ToList();

        public IEnumerable<Student> GetStudentAll()
        => _context.Set<Student>().ToList();

        public IEnumerable<StudentModel> GetMapAll()
        {
            var query = from map in _context.StudentCourseMaps.ToList()
                        join course in GetCourseAll() on map.CourseId equals course.Id
                        join student in GetStudentAll() on map.StudentId equals student.Id
                        select new StudentModel
                        {
                            CourseName = course.CourseName,
                            BirthDate = student.BirthDate,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            CourseId = course.Id,
                            Id = map.Id,
                            StudentId = student.Id
                        };
            var model = _mapper.Map<List<StudentModel>>(query.ToList());
            return model;
        }

        public StudentModel GetByMap(int id)
        {
        
            var map = _context.StudentCourseMaps.Where(m => m.StudentId == id).ToList();
            var coursesId=map.Select(s=>s.CourseId).ToList();
            var student = _context.Students.FirstOrDefault(m => m.Id == id);
            var coures = _context.Courses.Where(m => coursesId.Any(c => c == m.Id)).Select(s => new CourseModel
            {
                Id = s.Id,
                CourseId = s.CourseId,
                CourseName = s.CourseName
            }).ToList();

            return new StudentModel
            {
                Details = coures,
                Id = id,
                BirthDateTime = student.BirthDate.ToShortDateString(),
                FirstName = student.FirstName,
                LastName = student.LastName,
                StudentId = student.Id,
            };
        }

        public StudentCourseMapListModel GetStudentAndCourseMap()
        {
            var students = GetStudentAll().ToList();
            var course = GetCourseAll().ToList();

            var model = new StudentCourseMapListModel
            {
                CourseName = course,
                StudentName = students,
            };
            return model;
        }

        public bool CourseValidation(int id, int courseId)
        {
            var item = _context.StudentCourseMaps.Where(s => s.StudentId == id && s.CourseId != 0 && s.CourseId == courseId).FirstOrDefault();
            if (item == null)
            {
                return true;
            }
            return false;
        }
    }
}
