using CourseStore.Model.Framework;
using CourseStore.Model.Tags.Dtos;
using CourseStore.Model.Tags.Entities;
using MediatR;

namespace CourseStore.Model.Tags.Queries;

public class FilterTagByName:IRequest<ApiResult<ICollection<Tag>>>
{
    public string? TagName { get; set; }
}