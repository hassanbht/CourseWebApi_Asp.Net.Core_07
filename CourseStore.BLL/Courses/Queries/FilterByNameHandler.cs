

namespace CourseWebApi.BLL.Courses.Queries;

//public class FilterByNameHandler : BaseApplicationServiceHandler<FilterTagByName, ICollection<TagQuery>>
//{
//    public FilterByNameHandler(CourseStoreDbContext courseStoreDbContext) : base(courseStoreDbContext)
//    {
//    }

//    protected override async Task HandleRequest(FilterTagByName? request, CancellationToken cancellationToken)
//    {
//        var result = await _courseStoreDbContext.Tags.WhereOver(request?.TagName!).ToTagQrAsync();
//        AddResult(result);
//    }
//}