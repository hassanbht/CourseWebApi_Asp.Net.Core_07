using CourseStore.Model.Framework;
using CourseStore.Model.Tags.Dtos;
using MediatR;

namespace CourseStore.Model.Tags.Queries;

public class FilterByName:IRequest<ApiResult<ICollection<TagQuery>>>
{
    public string? TagName { get; set; }
}