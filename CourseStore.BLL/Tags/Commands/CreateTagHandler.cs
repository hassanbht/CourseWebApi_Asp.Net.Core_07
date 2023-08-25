using CourseStore.BLL.Framework;
using CourseStore.DAL.Contexts;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;
using CourseWebApi.Model.Repositories;

namespace CourseStore.BLL.Tags.Commands;

public class CreateCoursesHandler : BaseApplicationServiceHandler<CreateTag, Tag>
{
    public CreateCoursesHandler(IRepository<Tag> repository) : base(repository)
    {
    }

    protected override async Task HandleRequest(CreateTag request, CancellationToken cancellationToken)
    {
        Tag tag = new Tag(request.TagName);
        await _repository.AddAsync(tag,cancellationToken);
        //await _repository.SaveChangesAsync(cancellationToken);
        AddResult(tag);
    }
}



