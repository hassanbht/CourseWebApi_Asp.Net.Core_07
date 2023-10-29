using CourseWebApi.Model.Courses.Entities;
using CourseWebApi.Model.Framework;

namespace CourseWebApi.Model.Tags.Entities;

public class Tag : BaseEntity
{
    public Tag()
    {

    }
    public Tag(string tagName)
    {
        TagName = tagName;
    }

    public string TagName { get; set; }
    public ICollection<CourseTag>? CourseTags { get; set; }
}
