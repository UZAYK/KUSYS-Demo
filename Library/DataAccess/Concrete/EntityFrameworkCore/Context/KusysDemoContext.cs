using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using KUSYSDemo.Entities;
using KUSYSDemo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class KusysDemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.\\SQLEXPRESS; Initial Catalog = KusysDemoDB; Integrated Security = True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new StudentCourseMaps());

            base.OnModelCreating(modelBuilder);

            ///We have added ready-made data to the project, so you can integrate the SeedData we 
            ///adapted using CodeFirst technology into your database with "add-migration migrationName" and then 
            ///"update-database" calls.
            new CourseInitializer(modelBuilder).Seed();

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourseMap> StudentCourseMaps { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
