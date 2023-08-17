using CourseStore.Model.Framework;
using CourseWebApi.Model.Auth.Commands;
using CourseWebApi.Model.Auth.Dtos;
using CourseWebApi.Model.Auth.Queries;
using CourseWebApi.Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CourseWebApi.BLL.Infra
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
