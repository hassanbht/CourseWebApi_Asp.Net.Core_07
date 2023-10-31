using CourseWebApi.Model.Framework;
using CourseWebApi.Model.Repositories;
using MediatR;

namespace CourseWebApi.BLL.Framework;

public abstract class BaseApplicationServiceHandler<TRequest, TResult> : IRequestHandler<TRequest, ApiResult<TResult>>
    where TRequest : IRequest<ApiResult<TResult>> where TResult : BaseEntity
{

    protected readonly IRepository<TResult> _repository;
    protected ApiResult<TResult> _response = new ApiResult<TResult>();


    public BaseApplicationServiceHandler(IRepository<TResult> repository)
    {
        _repository = repository;
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

    //public void AddListResult(ICollection<TResult> result) =>
    //  _response.ListResult = result;

}