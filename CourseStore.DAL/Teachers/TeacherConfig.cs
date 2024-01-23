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
        //builder.Ignore(c => c.Address);
        //builder.Ignore(c => c.Cars);
        //builder.OwnsOne(c => c.Address, a =>
        //{
        //    a.Property(p => p.Street).HasMaxLength(50);
        //    a.Property(p => p.City).HasMaxLength(50);
        //    a.Property(p => p.State).HasMaxLength(50);
        //    a.Property(p => p.ZipCode).HasMaxLength(10);
        //});
        //builder.OwnsMany(c => c.Cars, a =>
        //{
        //    a.Property(p => p.CarName).HasMaxLength(100);
        //});
    }
}