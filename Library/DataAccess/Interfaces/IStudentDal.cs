using KUSYSDemo.Entities.Concrete;

namespace KUSYSDemo.DataAccess.Interfaces
{
    public interface IStudentDal : IGenericDal<Student>
    {
        Boolean CourseValidation(int id, int courseId);
    }
}
