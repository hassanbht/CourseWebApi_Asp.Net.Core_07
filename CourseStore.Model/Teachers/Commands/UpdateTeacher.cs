using CourseWebApi.Model.Courses.Entities;
using CourseWebApi.Model.Framework;
using CourseWebApi.Model.Teachers.Entities;
using MediatR;

namespace CourseWebApi.Model.Teachers.Commands
{
    public class UpdateTeacher:IRequest<ApiResult<CourseTeacher>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public List<CourseTeacher>? CourseTeachers { get; set; }
        public List<Car>? Cars { get; set; }
        public Address? Address { get; set; }
    }
}
