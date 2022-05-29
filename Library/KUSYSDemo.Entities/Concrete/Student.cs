using KUSYSDemo.Entities.Interfaces;

namespace KUSYSDemo.Entities.Concrete
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int? CourseId { get; set; }
    }
}
