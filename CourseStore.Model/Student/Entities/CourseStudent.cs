using CourseWebApi.Model.Courses.Entities;
using CourseWebApi.Model.Framework;

namespace CourseWebApi.Model.Student.Entities;

public class CourseStudent : BaseEntity
{
    public Course Course { get; set; }
    public Student Student { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
}
