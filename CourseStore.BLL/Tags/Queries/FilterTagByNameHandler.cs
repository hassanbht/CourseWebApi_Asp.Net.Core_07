using CourseWebApi.BLL.Framework;
using CourseWebApi.Model.Repositories;
using CourseWebApi.Model.Tags.Entities;
using CourseWebApi.Model.Tags.Queries;

namespace CourseWebApi.BLL.Tags.Queries;

public class FilterTagByNameHandler : BaseListApplicationServiceHandler<FilterTagByName, Tag>
{
    public FilterTagByNameHandler(IRepository<Tag> repository) : base(repository)
    {
    }

    protected override async Task HandleRequest(FilterTagByName? request, CancellationToken cancellationToken)
    {
        ICollection<Tag> tags;
        if (request == null || string.IsNullOrEmpty(request.TagName))
            tags = await _repository.GetAll();
        else
            tags = await _repository.Find(t => t.TagName.Contains(request!.TagName!));
        AddResult(tags);

    }

}