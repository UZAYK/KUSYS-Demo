using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;
using KUSYSDemo.Entities;
using KUSYSDemo.Entities.Interfaces;
using System.Linq.Expressions;

namespace KUSYSDemo.DataAccess.Interfaces
{
    public interface IGenericDal<T> where T : class, new()
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Add(T entity, dynamic model);
        void Remove(T entity);
        void Update(T entity);
        void Update(dynamic entity, dynamic id);
    }
}
