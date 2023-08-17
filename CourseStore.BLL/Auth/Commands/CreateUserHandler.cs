using CourseStore.BLL.Framework;
using CourseStore.DAL.Contexts;
using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Entities;
using CourseWebApi.BLL.Framework;
using CourseWebApi.BLL.Infra;
using CourseWebApi.Model.Auth.Commands;
using CourseWebApi.Model.Auth.Dtos;

namespace CourseStore.BLL.Tags.Commands;

public class CreateUserHandler : BaseAuthServiceHandler<CreateUserCommand, AuthenticationResponse>
{
    public CreateUserHandler(IAuthService authService) : base(authService)
    {
    }

    protected override async Task HandleRequest(CreateUserCommand request, CancellationToken cancellationToken)
    {
        AuthenticationResponse response= await _authService.RegisterAsync(request);
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



