using AutoMapper;
using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;
using KUSYSDemo.DataAccess.Interfaces;
using KUSYSDemo.Entities.Concrete;

namespace KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Repository
{
    public class EfStudentRepository : EfGenericRepository<Student>, IStudentDal
    {
        private readonly KusysDemoContext _context;
        public EfStudentRepository(KusysDemoContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public bool CourseValidation(int id, int courseId)
        {
            var item = _context.Courses.Where(s => s.Id == id && s.Id != 0 && s.Id != courseId).FirstOrDefault();
            if (item != null)
            {
                return false;
            }
            return true;
        }
    }
}
