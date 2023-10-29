using CourseWebApi.Model.Tags.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWebApi.DAL.Tags;

public class TagConfig : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(t => t.TagName).IsRequired().HasMaxLength(100).IsUnicode();
        builder.Property<bool>("IsDeleted");
        builder.HasQueryFilter(t => EF.Property<bool>(t, "IsDeleted") == false);
    }
}