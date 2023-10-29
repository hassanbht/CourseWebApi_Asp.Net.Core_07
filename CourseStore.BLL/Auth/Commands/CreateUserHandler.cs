using CourseWebApi.BLL.Framework;
using CourseWebApi.Model.Auth.Commands;
using CourseWebApi.Model.Auth.Dtos;
using CourseWebApi.Model.Services;

namespace CourseWebApi.BLL.Auth.Commands;

public class CreateUserHandler : BaseAuthServiceHandler<CreateUserCommand, AuthenticationResponse>
{
    public CreateUserHandler(IAuthService authService) : base(authService)
    {
    }

    protected override async Task HandleRequest(CreateUserCommand request, CancellationToken cancellationToken)
    {
        AuthenticationResponse response = await _authService.RegisterAsync(request);
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



