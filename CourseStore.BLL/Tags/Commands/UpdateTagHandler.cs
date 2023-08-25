using CourseStore.BLL.Framework;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;
using CourseWebApi.Model.Repositories;

namespace CourseStore.BLL.Tags.Commands;

public class UpdateTagHandler : BaseApplicationServiceHandler<UpdateTag, Tag>
{
    public UpdateTagHandler(IRepository<Tag> repository) : base(repository)
    {
    }
    protected override async Task HandleRequest(UpdateTag request, CancellationToken cancellationToken)
    {
        Tag? tag = await _repository.GetById(request.TagId);
        if (tag == null)
        {
            AddError($"تگ با شناسه {request.TagId} یافت نشد");
        }
        else
        {
            tag.TagName = request.TagName;
            await _repository.Update(tag);
            AddResult(tag);
        }
    }
}



