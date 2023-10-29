using CourseWebApi.Model.Courses.Entities;
using CourseWebApi.Model.Framework;

namespace CourseWebApi.Model.Teachers.Entities;

public class Teacher : BaseEntity
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public ICollection<CourseTeacher>? CourseTeachers { get; set; }
    public ICollection<Car>? Cars { get; set; }
    public Address? Address { get; set; }

}


