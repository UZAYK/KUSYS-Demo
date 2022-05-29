using System.ComponentModel.DataAnnotations;

namespace KUSYSDemo.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} the field should not be left empty!")]
        [Display(Name = "Name")] 

        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} the field should not be left empty!")]
        public string? LastName { get; set; }

        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "{0} the field should not be left empty!")]
        public DateTime BirthDate { get; set; }


        public int CourseId { get; set; }
        public string CourseName { get; set; }

    }
}
