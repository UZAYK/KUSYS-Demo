using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Models;

namespace KUSYSDemo.Business.Interfaces
{
    public interface IStudentCourseMapService : IGenericService<StudentCourseMap>
    {
        IEnumerable<Student> GetStudentAll();
        IEnumerable<Course> GetCourseAll();
        IEnumerable<StudentModel> GetMapAll();
        //bool CourseValidation(int studentId, string courseId);
    }
}
