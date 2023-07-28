using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Framework;
using CourseStore.Model.Tags.Entities;
using CourseStore.Model.Teachers.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseWebApi.Model.Courses.Commands
{
    public class CreateCourse : IRequest<ApiResult<Course>>
    {
        public CreateCourse(string title, string shortDescription, string description, DateTime startDate, DateTime endTime, int price, string imageUrl, ICollection<Tag> courseTags, ICollection<Teacher> courseTeachers, ICollection<CourseComment> courseComments)
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
        }

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
}
