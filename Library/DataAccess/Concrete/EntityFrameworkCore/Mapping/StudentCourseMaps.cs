using KUSYSDemo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class StudentCourseMaps : IEntityTypeConfiguration<StudentCourseMap>
    {
        public void Configure(EntityTypeBuilder<StudentCourseMap> builder)
        {
            /// Gives properties primary Key
            builder.HasKey(I => I.Id);

            /// It ensures that the relevant field is of an ascending type, that is, identity.
            builder.Property(I => I.Id).UseIdentityColumn();
        }
    }
}
