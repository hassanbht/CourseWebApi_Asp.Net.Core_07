using CourseStore.BLL.Framework;
using CourseStore.DAL.Contexts;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;

namespace CourseStore.BLL.Tags.Commands;

public class CreateCoursesHandler : BaseApplicationServiceHandler<CreateTag, Tag>
{
    public CreateCoursesHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
    {
    }

    protected override async Task HandleRequest(CreateTag request, CancellationToken cancellationToken)
    {
        Tag tag = new Tag(request.TagName);
        await _courseStoreDbContext.Tags.AddAsync(tag);
        await _courseStoreDbContext.SaveChangesAsync();
        AddResult(tag);
    }
}



