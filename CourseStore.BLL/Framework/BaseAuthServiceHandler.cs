using CourseStore.Model.Framework;
using CourseWebApi.Model.Services;
using MediatR;

namespace CourseWebApi.BLL.Framework
{
    public abstract class BaseAuthServiceHandler<TRequest, TResult> : IRequestHandler<TRequest, ApiResult<TResult>>
    where TRequest : IRequest<ApiResult<TResult>>
    {
        protected ApiResult<TResult> _response = new ApiResult<TResult> { };
        protected readonly IAuthService _authService;

        public BaseAuthServiceHandler(IAuthService authService)
        {
            this._authService = authService;
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
}
