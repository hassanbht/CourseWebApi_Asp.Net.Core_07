using CourseStore.Model.Framework;
using CourseStore.Model.Tags.Dtos;
using CourseWebApi.Model.Courses.Dtos;
using MediatR;

namespace CourseStore.Model.Tags.Queries;

public class FilterCourseByTitel:IRequest<ApiResult<ICollection<CourseQuery>>>
{
    public string? Titel { get; set; }
}