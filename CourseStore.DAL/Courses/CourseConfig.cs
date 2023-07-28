using CourseStore.Model.Courses.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseStore.DAL.Courses;

public class CourseConfig : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(c => c.Title).IsRequired().HasMaxLength(100).IsUnicode();
        builder.Property(c => c.ImageUrl).IsRequired().HasMaxLength(1000);
        builder.Property(c => c.Description).IsRequired().IsUnicode();
        builder.Property(c => c.Price).IsRequired();
        builder.Property(c => c.StartDate).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(c => c.ShortDescription).IsRequired().HasMaxLength(500).IsUnicode();
        builder.Property(c => c.RowVersion).IsRowVersion();
    }
}