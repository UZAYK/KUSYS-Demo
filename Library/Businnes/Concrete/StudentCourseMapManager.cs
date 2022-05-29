using KUSYSDemo.Business.Interfaces;
using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;
using KUSYSDemo.DataAccess.Interfaces;
using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Models;
using KUSYSDemo.Models.StudentCourseMap;
using System.Linq.Expressions;

namespace KUSYSDemo.Business.Concrete
{
    public class StudentCourseMapManager : IStudentCourseMapService
    {
        #region ctor
        private readonly IStudentCourseMapDal _studentCourseMapDal;
        private readonly KusysDemoContext _context;

        public StudentCourseMapManager(IStudentCourseMapDal studentCourseMapDal, KusysDemoContext context)
        {
            _studentCourseMapDal = studentCourseMapDal;
            _context = context;
        }

        #endregion

        public void Add(StudentCourseMap entity)
        => _studentCourseMapDal.Add(entity);

        //public void Add(StudentCourseMapAddModel entity, dynamic id)
        //=> _studentCourseMapDal.Add(entity, id);

        public void Add(StudentCourseMap entity, dynamic model)
        => _studentCourseMapDal.Add(entity, model);

        public IEnumerable<StudentCourseMap> Find(Expression<Func<StudentCourseMap, bool>> expression)
        => _studentCourseMapDal.Find(expression);

        public void Remove(StudentCourseMap entity)
        => _studentCourseMapDal.Remove(entity);

        public IEnumerable<StudentCourseMap> GetAll()
        => _studentCourseMapDal.GetAll();

        public StudentCourseMap GetById(int id)
        => _studentCourseMapDal.GetById(id);

        public void Update(StudentCourseMap entity)
        => _studentCourseMapDal.Update(entity);

        public void Update(dynamic model, dynamic id)
        => _studentCourseMapDal.Update(model, id);

        public IEnumerable<Student> GetStudentAll()
        => _studentCourseMapDal.GetStudentAll();

        public IEnumerable<Course> GetCourseAll()
        => _studentCourseMapDal.GetCourseAll();

        public IEnumerable<StudentModel> GetMapAll()
         => _studentCourseMapDal.GetMapAll();

        public StudentCourseMapListModel GetStudentAndCourseMap()
        => _studentCourseMapDal.GetStudentAndCourseMap();

        public bool CourseValidation(int id, int courseId)
        => _studentCourseMapDal.CourseValidation(id, courseId);
    }
}
