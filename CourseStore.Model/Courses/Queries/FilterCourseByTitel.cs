using CourseWebApi.Model.Courses.Dtos;
using CourseWebApi.Model.Framework;
using MediatR;

namespace CourseWebApi.Model.Courses.Queries;

public class FilterCourseByTitel : IRequest<ApiResult<ICollection<CourseModel>>>
{
    public string? Titel { get; set; }
}