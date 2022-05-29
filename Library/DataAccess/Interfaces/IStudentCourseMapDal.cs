using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Models;
using KUSYSDemo.Models.StudentCourseMap;
using System.Linq.Expressions;

namespace KUSYSDemo.DataAccess.Interfaces
{
    public interface IStudentCourseMapDal : IGenericDal<StudentCourseMap>
    {
        IEnumerable<Student> GetStudentAll();
        IEnumerable<Course> GetCourseAll();
        IEnumerable<StudentModel> GetMapAll();
        StudentCourseMapListModel GetStudentAndCourseMap();
        Boolean CourseValidation(int id, int courseId);

        //bool CourseValidation(Expression<Func<StudentCourseMap, bool>> expression);
    }
}
