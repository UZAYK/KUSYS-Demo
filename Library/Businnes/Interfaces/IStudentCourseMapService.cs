using KUSYSDemo.Models;
using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Models.StudentCourseMap;

namespace KUSYSDemo.Business.Interfaces
{
    public interface IStudentCourseMapService : IGenericService<StudentCourseMap>
    {
        IEnumerable<Student> GetStudentAll();
        IEnumerable<Course> GetCourseAll();
        IEnumerable<StudentModel> GetMapAll();
        StudentModel GetByMap(int id);
        StudentCourseMapListModel GetStudentAndCourseMap();
        Boolean CourseValidation(int id, int courseId);

    }
}
