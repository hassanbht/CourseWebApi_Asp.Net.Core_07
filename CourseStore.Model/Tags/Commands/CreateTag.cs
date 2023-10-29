using CourseWebApi.Model.Framework;
using CourseWebApi.Model.Tags.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CourseWebApi.Model.Tags.Commands;

public class CreateTag : IRequest<ApiResult<Tag>>
{
    public CreateTag()
    {

    }
    public CreateTag(string tagName)
    {
        TagName = tagName;
    }

    //[Required, StringLength(50, MinimumLength = 2)]
    public string TagName { get; set; }
}
