using CourseStore.Model.Framework;
using CourseStore.Model.Tags.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseStore.Model.Tags.Commands;

public class DeleteTag : IRequest<ApiResult<Tag>>
{
    public DeleteTag(int tagId)
    {
        TagId = tagId;
    }

    [Required, Range(1, int.MaxValue)]
    public int TagId { get; set; }
}