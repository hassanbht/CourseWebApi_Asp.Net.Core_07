using CourseWebApi.Model.Framework;
using CourseWebApi.Model.Tags.Entities;
using MediatR;

namespace CourseWebApi.Model.Tags.Queries;

public class FilterTagByName : IRequest<ApiResult<ICollection<Tag>>>
{
    public string? TagName { get; set; }
}