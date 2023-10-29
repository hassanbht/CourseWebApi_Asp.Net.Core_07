using CourseWebApi.BLL.Framework;
using CourseWebApi.Model.Auth.Commands;
using CourseWebApi.Model.Auth.Dtos;
using CourseWebApi.Model.Auth.Queries;
using CourseWebApi.Model.Services;

namespace CourseWebApi.BLL.Auth.Queries;

public class GetRefreshTokenHandler : BaseAuthServiceHandler<TokenQueriy, TokenModel>
{
    public GetRefreshTokenHandler(IAuthService authService) : base(authService)
    {
    }

    protected override async Task HandleRequest(TokenQueriy request, CancellationToken cancellationToken)
    {
        TokenModel response = await _authService.RefreshTokenAsync(request);
        if (response == null || response != null && !string.IsNullOrEmpty(response.Message))
        {
            AddError(response?.Message!);
        }
        else
        {
            AddResult(response!);
        }
    }
}



