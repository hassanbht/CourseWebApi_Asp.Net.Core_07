using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Framework;

namespace CourseWebApi.Model.Student.Entities
{
    public class Student : BaseEntity
    {
        public string StudentNumber { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Description { get; init; }
        public ICollection<PhoneNumber> PhoneNumbers { get; init; }
        public ICollection<Course>? Courses { get; set; }
    }
}
