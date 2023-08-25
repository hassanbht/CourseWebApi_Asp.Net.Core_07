using CourseStore.BLL.Framework;
using CourseStore.Model.Tags.Entities;
using CourseStore.Model.Tags.Queries;
using CourseWebApi.Model.Repositories;

namespace CourseStore.BLL.Tags.Queries;

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