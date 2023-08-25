using CourseStore.BLL.Framework;
using CourseStore.DAL.Contexts;
using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;
using CourseWebApi.BLL.Framework;
using CourseWebApi.Model.Auth.Commands;
using CourseWebApi.Model.Auth.Dtos;
using CourseWebApi.Model.Services;

namespace CourseStore.BLL.Tags.Commands;

public class LoginHandler : BaseAuthServiceHandler<LoginCommand, AuthenticationResponse>
{
    public LoginHandler(IAuthService authService) : base(authService)
    {
    }

    protected override async Task HandleRequest(LoginCommand request, CancellationToken cancellationToken)
    {
        AuthenticationResponse response= await _authService.LoginAsync(request);
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



