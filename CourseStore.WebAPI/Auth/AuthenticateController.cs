using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Queries;
using CourseStore.WebAPI.Framework;
using CourseWebApi.Model.Auth.Commands;
using CourseWebApi.Model.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseStore.WebAPI.Tags;

public class AuthenticateController : BaseController
{
    public AuthenticateController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser(CreateUserCommand createUser)
    {
        var response = await _mediator.Send(createUser);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }

    [HttpPut("Login")]
    public async Task<IActionResult> Login(LoginCommand user)
    {
        var response = await _mediator.Send(user);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }


    [HttpPost("GetRefreshToken")]
    public async Task<IActionResult> GetRefreshToken(TokenQueriy token)
    {
        var response = await _mediator.Send(token);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
}
