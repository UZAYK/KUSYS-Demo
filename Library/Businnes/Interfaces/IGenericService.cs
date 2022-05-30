using System.Linq.Expressions;

namespace KUSYSDemo.Business.Interfaces
{
    public interface IGenericService<T> where T : class, new()
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
