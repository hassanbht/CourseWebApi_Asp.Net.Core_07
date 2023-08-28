using CourseWebApi.Model.Courses.Dtos;

namespace CourseWebApi.Model.Teachers.Dtos
{
    public class TeacherModel
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public List<CourseModel>? CourseTeachers { get; set; }
        public List<CarModel>? Cars { get; set; }
        public AddressModel? Address { get; set; }
    }
}
