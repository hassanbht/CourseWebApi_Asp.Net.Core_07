using Azure;
using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Queries;
using CourseStore.WebAPI.Framework;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CourseStore.WebAPI.Tags;
[Authorize]
public class TagsController : BaseController
{
    public TagsController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("CreateTag")]
    public async Task<IActionResult> CreateTag(CreateTag tag, IValidator<CreateTag> validator)
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
    public async Task<IActionResult> UpdateTag(UpdateTag tag, IValidator<UpdateTag> validator)
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
    public async Task<IActionResult> SearchTag([FromQuery] FilterTagByName tag)
    {
        var response = await _mediator.Send(tag);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
}
