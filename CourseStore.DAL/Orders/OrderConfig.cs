using CourseStore.Model.Orders.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseStore.DAL.Courses;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.CustomerEmail).IsRequired().HasMaxLength(100);
        builder.Property(o => o.OrderDate).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(o => o.Price).IsRequired();
        builder.Property(o => o.CustomerEmail).HasMaxLength(100).IsUnicode(false);

    }
}