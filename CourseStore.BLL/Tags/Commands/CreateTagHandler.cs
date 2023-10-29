using CourseWebApi.BLL.Framework;
using CourseWebApi.Model.Repositories;
using CourseWebApi.Model.Tags.Commands;
using CourseWebApi.Model.Tags.Entities;

namespace CourseWebApi.BLL.Tags.Commands;

public class CreateCoursesHandler : BaseApplicationServiceHandler<CreateTag, Tag>
{
    public CreateCoursesHandler(IRepository<Tag> repository) : base(repository)
    {
    }

    protected override async Task HandleRequest(CreateTag request, CancellationToken cancellationToken)
    {
        Tag tag = new Tag(request.TagName);
        await _repository.AddAsync(tag, cancellationToken);
        AddResult(tag);
    }
}



