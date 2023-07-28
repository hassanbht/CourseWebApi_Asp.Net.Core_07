using CourseStore.DAL.Contexts;
using CourseStore.Model.Framework;
using MediatR;

namespace CourseStore.BLL.Framework;

public abstract class BaseApplicationServiceHandler<TRequest, TResult> : IRequestHandler<TRequest, ApiResult<TResult>>
    where TRequest : IRequest<ApiResult<TResult>>
{
    protected readonly CourseStoreDbContext _courseStoreDbContext;
    protected ApiResult<TResult> _response = new ApiResult<TResult> { };
    public BaseApplicationServiceHandler(CourseStoreDbContext courseStoreDbContext)
    {
        _courseStoreDbContext = courseStoreDbContext;
    }

    public async Task<ApiResult<TResult>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await HandleRequest(request, cancellationToken);
        return _response;
    }
    protected abstract Task HandleRequest(TRequest request, CancellationToken cancellationToken);

    public void AddError(string error)
    {
        _response.AddError(error);
    }

    public void AddResult(TResult result) =>
        _response.Result = result;

}