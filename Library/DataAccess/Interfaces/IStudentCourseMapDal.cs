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
        StudentModel GetByMap(int id);
        StudentCourseMapListModel GetStudentAndCourseMap();
        Boolean CourseValidation(int id, int courseId);
    }
}
