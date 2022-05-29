using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;
using KUSYSDemo.Entities.Concrete;

namespace KUSYSDemo.Business.Interfaces
{
    public interface IStudentService : IGenericService<Student>
    {
        object Repository<T>(KusysDemoContext ctx);
    }
}
