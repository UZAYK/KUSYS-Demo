using KUSYSDemo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class StudentCourseMaps : IEntityTypeConfiguration<StudentCourseMap>
    {
        public void Configure(EntityTypeBuilder<StudentCourseMap> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
        }
    }
}
