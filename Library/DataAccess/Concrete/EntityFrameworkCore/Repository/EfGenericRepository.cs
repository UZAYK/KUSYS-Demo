using AutoMapper;
using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;
using KUSYSDemo.DataAccess.Interfaces;
using KUSYSDemo.Entities.Interfaces;
using System.Linq.Expressions;

namespace KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Repository
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        #region constructor transactions (dependency incjection)
        private readonly KusysDemoContext _context;
        private readonly IMapper _mapper;

        public EfGenericRepository(KusysDemoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Add(T entity, dynamic model)
        {
            var map = _mapper.Map<T>(model);
            _context.Set<T>().Add(map);
            _context.SaveChanges();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        => _context.Set<T>().Where(expression);

        public IEnumerable<T> GetAll()
        => _context.Set<T>().ToList();

        public T GetById(int id)
        => _context.Set<T>().Find(id);

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public void Update(dynamic entity, dynamic id)
        {
            var map = _mapper.Map(entity, id);
            _context.Set<T>().Update(map);
            _context.SaveChanges();
        }
    }
}