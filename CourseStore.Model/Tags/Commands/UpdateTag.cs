using CourseStore.Model.Framework;
using CourseStore.Model.Tags.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseStore.Model.Tags.Commands;

public class UpdateTag : IRequest<ApiResult<Tag>>
{
    public UpdateTag(int tagId, string tagName)
    {
        TagId = tagId;
        TagName = tagName;
    }

    //[Required, Range(1, int.MaxValue)]
    public int TagId { get; set; }
    //[Required, StringLength(50, MinimumLength = 2)]
    public string TagName { get; set; }
}