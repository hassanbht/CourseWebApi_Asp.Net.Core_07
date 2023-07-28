using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Tags.Entities;
using CourseStore.Model.Teachers.Entities;
using CourseWebApi.Model.Teachers.Entities;

namespace CourseWebApi.Model.Courses.Dtos
{
    public class CourseQuery
    {
        public CourseQuery(int id, string title, string shortDescription, string description, DateTime startDate, DateTime endTime, int price, string imageUrl, List<Tag> tags, List<Teacher> teachers, List<CourseComment> comments, byte[] rowVersion)
        {
            Id = id;
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            StartDate = startDate;
            EndTime = endTime;
            Price = price;
            ImageUrl = imageUrl;
            Tags = tags;
            Teachers = teachers;
            Comments = comments;
            RowVersion = rowVersion;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<CourseComment> Comments { get; set; }
        public Byte[] RowVersion { get; set; }
    }

   
}
