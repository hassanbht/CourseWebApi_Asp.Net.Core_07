using CourseWebApi.Model.Framework;
using CourseWebApi.Model.Tags.Entities;

namespace CourseWebApi.Model.Courses.Entities;

public class CourseTag : BaseEntity
{
    public int CourseId { get; set; }
    public int TagId { get; set; }
    public Course Course { get; set; }
    public Tag Tag { get; set; }
}