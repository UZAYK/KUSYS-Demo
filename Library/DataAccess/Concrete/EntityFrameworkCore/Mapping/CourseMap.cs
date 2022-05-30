using KUSYSDemo.Entities;
using KUSYSDemo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            /// Gives properties primary Key
            builder.HasKey(I => I.Id);

            /// It ensures that the relevant field is of an ascending type, that is, identity.
            builder.Property(I => I.Id).UseIdentityColumn();

            /// We have limited this field to a certain character.
            builder.Property(I => I.CourseName).HasMaxLength(74);
        }
    }
}
