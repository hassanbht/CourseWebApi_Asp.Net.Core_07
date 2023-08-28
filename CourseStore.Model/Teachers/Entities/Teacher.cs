using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Framework;
using CourseWebApi.Model.Teachers.Entities;

namespace CourseStore.Model.Teachers.Entities;

public class Teacher : BaseEntity
{
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public ICollection<CourseTeacher>? CourseTeachers { get; set; }
    public ICollection<Car>? Cars { get; set; }
    public Address? Address { get; set; }

}


