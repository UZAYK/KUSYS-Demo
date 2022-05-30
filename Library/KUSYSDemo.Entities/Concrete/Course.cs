using KUSYSDemo.Entities.Interfaces;

namespace KUSYSDemo.Entities.Concrete
{
    public class Course : BaseEntity
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
