using CourseStore.Model.Framework;
using CourseWebApi.Model.Student.Entities;

namespace CourseStore.Model.Courses.Entities;

public class CourseStudent : BaseEntity
{
    public Course Course { get; set; }
    public Student Student { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
}
