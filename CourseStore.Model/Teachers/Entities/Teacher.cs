using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Framework;
using CourseWebApi.Model.Teachers.Entities;

namespace CourseStore.Model.Teachers.Entities;

public class Teacher : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public List<CourseTeacher> CourseTeachers { get; set; }
    public List<Car> Cars { get; set; }
    public Address Address { get; set; }

}


