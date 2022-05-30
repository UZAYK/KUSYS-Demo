using System.ComponentModel.DataAnnotations;

namespace KUSYSDemo.Models
{
    public class CourseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} the field should not be left empty!")]
        [Display(Name = "Course Code")] 
        public string CourseId { get; set; }

        [Required(ErrorMessage = "{0} the field should not be left empty!")]
        [Display(Name = "Course Name")]
        public string? CourseName { get; set; }
    }
}
