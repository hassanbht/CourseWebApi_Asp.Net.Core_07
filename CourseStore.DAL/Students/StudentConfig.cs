using CourseWebApi.Model.Student.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWebApi.DAL.Students
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50).IsUnicode();
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(50).IsUnicode();
            builder.Property(s => s.Description).IsRequired().HasMaxLength(250).IsUnicode();
            builder.OwnsMany(t => t.PhoneNumbers, a =>
            {
                a.Property(p => p.Number).HasMaxLength(11).IsUnicode(false);
            });
        }
    }
}
