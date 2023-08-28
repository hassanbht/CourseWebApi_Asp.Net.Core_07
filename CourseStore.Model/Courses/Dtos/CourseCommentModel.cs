using CourseStore.Model.Courses.Entities;

namespace CourseWebApi.Model.Courses.Dtos
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public int CourseId { get; set; }
        public string Comment { get; set; }
        public string CommentBy { get; set; }
        public DateTime CommantDate { get; set; }
        public bool IsValid { get; set; }       
    }
}
