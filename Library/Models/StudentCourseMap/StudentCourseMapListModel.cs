using KUSYSDemo.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace KUSYSDemo.Models.StudentCourseMap
{
    public class StudentCourseMapListModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "{0} the field should not be left empty!")]
        [Display(Name = "Student Name")]
        public List<string> StudentId { get; set; }
        public List<Course> CourseName { get; set; }
        public List<Student> StudentName { get; set; }

        [Required(ErrorMessage = "{0} the field should not be left empty!")]
        [Display(Name = "Course Name")] 
        public List<string> CourseId { get; set; }
    }
}
