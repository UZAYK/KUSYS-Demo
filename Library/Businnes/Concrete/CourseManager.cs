using System.Linq.Expressions;

using KUSYSDemo.Business.Interfaces;
using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;
using KUSYSDemo.DataAccess.Interfaces;
using KUSYSDemo.Entities.Concrete;

namespace KUSYSDemo.Business.Concrete
{
    public class CourseManager : ICourseService
    {
        #region ctor
        private readonly ICourseDal _courseDal;
        private readonly KusysDemoContext _context;

        public CourseManager(ICourseDal courseDal, KusysDemoContext context)
        {
            _courseDal = courseDal;
            _context = context;
        }

        #endregion

        public void Add(Course entity)
        => _courseDal.Add(entity);

        public IEnumerable<Course> Find(Expression<Func<Course, bool>> expression)
        => _courseDal.Find(expression);

        public IEnumerable<Course> GetAll()
        => _courseDal.GetAll();

        public Course GetById(int id)
        => _courseDal.GetById(id);

        public void Remove(Course entity)
        => _courseDal.Remove(entity);

        public void Update(Course entity)
        => _courseDal.Update(entity);

        public void Update(dynamic model, dynamic id)
        => _courseDal.Update(model, id);
        public void Add(Course entity, dynamic id)
        => _courseDal.Add(entity, id);

        public void Add(dynamic entity, dynamic id)
        => _courseDal.Update(entity, id);
    }
}
