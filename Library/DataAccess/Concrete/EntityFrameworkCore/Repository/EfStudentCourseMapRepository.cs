using AutoMapper;
using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;
using KUSYSDemo.DataAccess.Interfaces;
using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Models;
using System.Linq.Expressions;

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

        //public bool CourseValidation(int studentId, string courseId)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool CourseValidation(Expression<Func<StudentCourseMap, bool>> expression)
        // => _context.Set<StudentCourseMap>().Where(expression).;

        public IEnumerable<Course> GetCourseAll()
        => _context.Set<Course>().ToList();

        public IEnumerable<Student> GetStudentAll()
         => _context.Set<Student>().ToList();

        public IEnumerable<StudentModel> GetMapAll()
        {
            var query = from student in GetStudentAll()
                        join course in GetCourseAll() on student.CourseId equals course.Id
                        select new StudentModel
                        {
                            CourseName = course.CourseName,
                            BirthDate = student.BirthDate,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            CourseId = course.Id,
                            Id = student.Id
                        };
            var model = _mapper.Map<List<StudentModel>>(query.ToList());
            return model;
        }

    }
}
