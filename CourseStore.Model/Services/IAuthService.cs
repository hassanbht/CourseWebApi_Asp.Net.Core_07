using CourseWebApi.Model.Auth.Commands;
using CourseWebApi.Model.Auth.Dtos;
using CourseWebApi.Model.Auth.Queries;

namespace CourseWebApi.Model.Services
{
    public interface IAuthService
    {
        Task<AuthenticationResponse> LoginAsync(LoginCommand user);
        Task<AuthenticationResponse> RegisterAsync(CreateUserCommand user);
        Task<string> RevokeUserAsync(string userName);
        Task RevokeAllAsync();
        Task<TokenModel> RefreshTokenAsync(TokenQueriy token);


    }
}
