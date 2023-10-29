using CourseWebApi.Model.Framework;
using CourseWebApi.Model.Teachers.Entities;

namespace CourseWebApi.Model.Courses.Entities;

public class CourseTeacher : BaseEntity
{
    public Course Course { get; set; }
    public Teacher Teacher { get; set; }
    public int TeacherId { get; set; }
    public int CourseId { get; set; }
    public int SortOrder { get; set; }
}
