using KUSYSDemo.Entities.Concrete;
using KUSYSDemo.Models;
using KUSYSDemo.Models.StudentCourseMap;

namespace KUSYSDemo.Business.Interfaces
{
    public interface IStudentCourseMapService : IGenericService<StudentCourseMap>
    {
        IEnumerable<Student> GetStudentAll();
        IEnumerable<Course> GetCourseAll();
        IEnumerable<StudentModel> GetMapAll();
        StudentCourseMapListModel GetStudentAndCourseMap();

        Boolean CourseValidation(int id, int courseId);
        //bool CourseValidation(int studentId, string courseId);
    }
}
