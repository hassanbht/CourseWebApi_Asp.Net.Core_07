using CourseStore.BLL.Framework;
using CourseStore.DAL.Contexts;
using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;
using CourseWebApi.BLL.Framework;
using CourseWebApi.BLL.Infra;
using CourseWebApi.Model.Auth.Commands;
using CourseWebApi.Model.Auth.Dtos;
using CourseWebApi.Model.Auth.Queries;

namespace CourseStore.BLL.Tags.Commands;

public class GetRefreshTokenHandler : BaseAuthServiceHandler<TokenQueriy, TokenModel>
{
    public GetRefreshTokenHandler(IAuthService authService) : base(authService)
    {
    }

    protected override async Task HandleRequest(TokenQueriy request, CancellationToken cancellationToken)
    {
        TokenModel response = await _authService.RefreshTokenAsync(request);
        if (response == null || response != null && !string.IsNullOrEmpty( response.Message))
        {
            AddError(response?.Message!);
        }
        else
        {
            AddResult(response!);
        }
    }
}



