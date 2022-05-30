using KUSYSDemo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class CourseInitializer
    {
        private ModelBuilder modelBuilder;

        public CourseInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        /// <summary>
        /// The data to be saved ready when the database commands are run.
        /// </summary>
        public void Seed()
        {
            modelBuilder.Entity<Course>().HasData(
                   new Course()
                   {
                       Id = 1,
                       CourseId = "CSI101",
                       CourseName = "Introduction to Computer Science",
                   }, new Course()
                   {
                       Id = 2,
                       CourseId = "CSI102",
                       CourseName = "Algorithms",
                   }, new Course()
                   {
                       Id = 3,
                       CourseId = "MAT101",
                       CourseName = "Calculus",
                   }, new Course()
                   {
                       Id = 4,
                       CourseId = "PHY101",
                       CourseName = "Physics",
                   }
            );
            modelBuilder.Entity<Student>().HasData(
                   new Student()
                   {
                       Id = 1,
                       FirstName = "Uzay",
                       LastName = "KAHRAMAN",
                       BirthDate = DateTime.Now,
                       CourseId = 0,
                   }, new Student()
                   {
                       Id = 2,
                       FirstName = "Yağmur",
                       LastName = "KAHRAMAN",
                       BirthDate = DateTime.Now,
                       CourseId = 0,
                   }
            );
        }
    }
}