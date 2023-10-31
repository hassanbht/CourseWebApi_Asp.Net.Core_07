using Azure;
using CourseWebApi.Model.Framework;
using CourseWebApi.Model.Tags.Commands;
using CourseWebApi.Model.Tags.Entities;
using CourseWebApi.Model.Tags.Queries;
using CourseWebApi.WebAPI.Framework;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CourseWebApi.WebAPI.Tags;
[Authorize]
public class TagsController : BaseController
{
    public TagsController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("CreateTag")]
    public async Task<ApiResult<Tag>> CreateTag(CreateTag tag, IValidator<CreateTag> validator)
    {
        ValidationResult result = await validator.ValidateAsync(tag);

        if (result.IsValid)
        {
            var response = await _mediator.Send(tag);
            return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
        }
        return BadRequest(result.Errors);
    }

    [HttpPut("UpdateTag")]
    public async Task<ApiResult<Tag>> UpdateTag(UpdateTag tag, IValidator<UpdateTag> validator)
    {
        ValidationResult result = await validator.ValidateAsync(tag);

        if (result.IsValid)
        {
            var response = await _mediator.Send(tag);
            return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
        }
        return BadRequest(result.Errors);
    }


    [HttpGet("SearchTag")]
    public async Task<ApiResult<ICollection<Tag>>> SearchTag([FromQuery] FilterTagByName tag)
    {
        var response = await _mediator.Send(tag);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
}
