using CourseWebApi.Model.Courses.Entities;
using CourseWebApi.Model.Framework;
using CourseWebApi.Model.Tags.Entities;
using CourseWebApi.Model.Teachers.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseWebApi.Model.Courses.Commands;

public class UpdateCourse : IRequest<ApiResult<Course>>
{
    public UpdateCourse(int id, string title, string shortDescription, string description, DateTime startDate, DateTime endTime, int price, string imageUrl, ICollection<Tag> courseTags, ICollection<Teacher> courseTeachers, ICollection<CourseComment> courseComments)
    {
        Id = id;
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
    }

    [Required, Range(1, int.MaxValue)]
    public int Id { get; set; }
    [Required, StringLength(100, MinimumLength = 2)]
    public string Title { get; set; }
    [Required, StringLength(500, MinimumLength = 2)]
    public string ShortDescription { get; set; }
    [Required, StringLength(5000, MinimumLength = 2)]
    public string Description { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime EndTime { get; set; }
    [Required]
    public int Price { get; set; }
    [Required, StringLength(1000, MinimumLength = 2)]
    public string ImageUrl { get; set; }
    public ICollection<Tag> CourseTags { get; set; }
    public ICollection<Teacher> CourseTeachers { get; set; }
    public ICollection<CourseComment> CourseComments { get; set; }
}