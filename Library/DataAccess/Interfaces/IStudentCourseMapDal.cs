using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Models;
using System.Linq.Expressions;

namespace KUSYSDemo.DataAccess.Interfaces
{
    public interface IStudentCourseMapDal : IGenericDal<StudentCourseMap>
    {
        IEnumerable<Student> GetStudentAll();
        IEnumerable<Course> GetCourseAll();
        IEnumerable<StudentModel> GetMapAll();
        //bool CourseValidation(Expression<Func<StudentCourseMap, bool>> expression);
        //bool CourseValidation();
    }
}
