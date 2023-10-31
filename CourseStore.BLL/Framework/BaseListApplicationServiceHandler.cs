using CourseWebApi.Model.Framework;
using CourseWebApi.Model.Repositories;
using MediatR;

namespace CourseWebApi.BLL.Framework;

public abstract class BaseListApplicationServiceHandler<TRequest, TResult> : IRequestHandler<TRequest, ApiResult<ICollection<TResult>>>
    where TRequest : IRequest<ApiResult<ICollection<TResult>>> where TResult : BaseEntity
{
    protected readonly IRepository<TResult> _repository;
    protected ApiResult<TResult> _response = new ApiResult<TResult>();
    protected ApiResult<ICollection<TResult>> _responseList = new ApiResult<ICollection<TResult>>{ };
   


    public BaseListApplicationServiceHandler(IRepository<TResult> repository)
    {
        _repository = repository;
    }


    public async Task<ApiResult<ICollection<TResult>>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await HandleRequest(request, cancellationToken);
        return _responseList;
    }
    protected abstract Task HandleRequest(TRequest request, CancellationToken cancellationToken);

    public void AddError(string error)
    {
        _responseList.AddError(error);
    }

    public void AddResult(ICollection<TResult> result) =>
        _responseList.Result = result;

}