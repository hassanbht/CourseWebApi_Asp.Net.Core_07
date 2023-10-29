using CourseWebApi.BLL.Framework;
using CourseWebApi.Model.Repositories;
using CourseWebApi.Model.Tags.Commands;
using CourseWebApi.Model.Tags.Entities;

namespace CourseWebApi.BLL.Tags.Commands;

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



