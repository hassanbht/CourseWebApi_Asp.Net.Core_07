using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Queries;
using CourseStore.WebAPI.Framework;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseStore.WebAPI.Tags;
[Authorize]
public class TagsController : BaseController
{
    public TagsController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("CreateTag")]
    public async Task<IActionResult> CreateTag(CreateTag tag)
    {
        var response = await _mediator.Send(tag);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }

    [HttpPut("UpdateTag")]
    public async Task<IActionResult> UpdateTag(UpdateTag tag)
    {
        var response = await _mediator.Send(tag);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }


    [HttpGet("SearchTag")]
    public async Task<IActionResult> SearchTag([FromQuery] FilterTagByName tag)
    {
        var response = await _mediator.Send(tag);
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
}
