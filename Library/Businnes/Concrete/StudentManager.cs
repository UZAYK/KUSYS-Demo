using System.Linq.Expressions;

using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Business.Interfaces;
using KUSYSDemo.DataAccess.Interfaces;
using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;

namespace KUSYSDemo.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        #region ctor
        private readonly IStudentDal _studentDal;
        private readonly KusysDemoContext _context;

        public StudentManager(IStudentDal studentDal, KusysDemoContext context)
        {
            _studentDal = studentDal;
            _context = context;
        }

        #endregion

        public void Add(Student entity)
        => _studentDal.Add(entity);

        public IEnumerable<Student> Find(Expression<Func<Student, bool>> expression)
        => _studentDal.Find(expression);

        public void Remove(Student entity)
        => _studentDal.Remove(entity);

        IEnumerable<Student> IGenericService<Student>.GetAll()
        => _studentDal.GetAll();

        Student IGenericService<Student>.GetById(int id)
        => _studentDal.GetById(id);

        public void Update(Student entity)
        => _studentDal.Update(entity);

        public void Update(dynamic model, dynamic id)
        => _studentDal.Update(model, id);

        public void Add(Student entity, dynamic id)
        => _studentDal.Add(entity, id);


        public void Add(dynamic entity, dynamic id)
        => _studentDal.Add(entity, id);

    }
}
