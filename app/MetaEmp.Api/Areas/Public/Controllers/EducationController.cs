using MetaEmp.Api.Abstractions;
using MetaEmp.Application.Features.Public.Educations;
using MetaEmp.Application.Features.Public.Educations.All;
using MetaEmp.Application.Features.Public.Educations.Create;
using MetaEmp.Application.Features.Public.Educations.Delete;
using MetaEmp.Application.Features.Public.Educations.One;
using MetaEmp.Application.Features.Public.Educations.Update;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Areas.Public.Controllers;

public class EducationController : ApiController
{
    [HttpGet("{specialistId}")]
    public async Task<EducationResult[]> GetAll(Guid specialistId)
        => await Mediator.Send(new GetEducationsRequest(specialistId));

    [HttpGet("{id}")]
    public async Task<EducationResult> GetOne([FromRoute] Guid id)
        => await Mediator.Send(new GetEducationRequest(id));

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateEducationRequest request)
    {
        var result = await Mediator.Send(request);
        return Created($"/v1/education/{result.Id}", result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEducationRequest request)
    {
        await Mediator.Send(request with {Id = id});
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        await Mediator.Send(new DeleteEducationRequest(id));
        return NoContent();
    }
}