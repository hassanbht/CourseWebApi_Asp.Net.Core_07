using CourseWebApi.Model.Framework;

namespace CourseWebApi.Model.Courses.Entities;

public class Course : BaseEntity
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndTime { get; set; }
    public int Price { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<CourseTag> CourseTags { get; set; }
    public ICollection<CourseTeacher> CourseTeachers { get; set; }
    public ICollection<CourseComment> CourseComments { get; set; }
    public byte[] RowVersion { get; set; }
}
