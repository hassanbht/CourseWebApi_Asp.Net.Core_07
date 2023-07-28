using CourseStore.Model.Framework;
using CourseStore.Model.Tags.Entities;

namespace CourseStore.Model.Courses.Entities;

public class Course : BaseEntity
{
    public Course()
    {
        
    }
    public Course(string title, string shortDescription, string description, DateTime startDate, DateTime endTime, int price, string imageUrl, ICollection<CourseTag> courseTags, ICollection<CourseTeacher> courseTeachers, ICollection<CourseComment> courseComments, byte[] rowVersion)
    {
        Title = title;
        ShortDescription = shortDescription;
        Description = description;
        StartDate = startDate;
        EndTime = endTime;
        Price = price;
        ImageUrl = imageUrl;
        CourseTags = courseTags;
        CourseTeachers = courseTeachers;
        CourseComments = courseComments;
        RowVersion = rowVersion;
    }

    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndTime { get; set; }
    public int Price { get; set; }
    public string  ImageUrl { get; set; }
    public ICollection<CourseTag> CourseTags { get; set; }
    public ICollection<CourseTeacher> CourseTeachers { get; set; }
    public ICollection<CourseComment> CourseComments { get; set; }
    public Byte[] RowVersion { get; set; }
}
