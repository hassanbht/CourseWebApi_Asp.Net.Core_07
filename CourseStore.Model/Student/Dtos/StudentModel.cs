using CourseWebApi.Model.Courses.Dtos;

namespace CourseWebApi.Model.Student.Dtos
{
    public class StudentModel
    {
        public int StudentId { get; init; }
        public string StudentNumber { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Description { get; init; }
        public List<PhoneNumberModel> PhoneNumbers { get; init; }
        public List<CourseModel>? Courses { get; set; }
    }
}
