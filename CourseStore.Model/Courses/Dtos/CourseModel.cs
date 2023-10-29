using CourseWebApi.Model.Tags.Dtos;
using CourseWebApi.Model.Teachers.Dtos;

namespace CourseWebApi.Model.Courses.Dtos
{
    public class CourseModel
    {

        public int CourseId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public List<TagModel> Tags { get; set; }
        public List<TeacherModel> Teachers { get; set; }
        public List<CommentModel> Comments { get; set; }
        public Byte[] RowVersion { get; set; }
    }


}
