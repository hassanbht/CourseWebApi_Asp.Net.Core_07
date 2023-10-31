using CourseWebApi.Model.Auth.Commands;
using CourseWebApi.Model.Auth.Dtos;
using CourseWebApi.Model.Auth.Queries;
using CourseWebApi.Model.Framework;
using CourseWebApi.WebAPI.Framework;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseWebApi.WebAPI.Auth;

public class AuthenticateController : BaseController
{
    public AuthenticateController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("CreateUser")]
    public async Task<ApiResult<AuthenticationResponse>> CreateUser(CreateUserCommand createUser)
    {
        var response = await _mediator.Send(createUser);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }

    [HttpPut("Login")]
    public async Task<ApiResult<AuthenticationResponse>> Login(LoginCommand user)
    {
        var response = await _mediator.Send(user);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }


    [HttpPost("GetRefreshToken")]
    public async Task<ApiResult<TokenModel>> GetRefreshToken(TokenQueriy token)
    {
        var response = await _mediator.Send(token);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
}
