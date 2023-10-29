using CourseWebApi.Model.Teachers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWebApi.DAL.Teachers;

public class TeacherConfig : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(t => t.FirstName).IsRequired().HasMaxLength(50).IsUnicode();
        builder.Property(t => t.LastName).IsRequired().HasMaxLength(50).IsUnicode();
        builder.Property(c => c.FullName).HasComputedColumnSql("FirstName + ' ' + LastName", true).IsUnicode();
    }
}