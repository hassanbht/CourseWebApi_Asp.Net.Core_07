using CourseStore.BLL.Framework;
using CourseStore.DAL.Contexts;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.BLL.Tags.Commands;

public class UpdateTagHandler : BaseApplicationServiceHandler<UpdateTag, Tag>
{
    public UpdateTagHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
    {
    }
    protected override async Task HandleRequest(UpdateTag request, CancellationToken cancellationToken)
    {
        Tag? tag = await _courseStoreDbContext.Tags.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);
        if (tag == null)
        {
            AddError($"تگ با شناسه {request.Id} یافت نشد");
        }
        else
        {
            tag.TagName = request.TagName;
            await _courseStoreDbContext.SaveChangesAsync();
            AddResult(tag);
        }
    }
}



