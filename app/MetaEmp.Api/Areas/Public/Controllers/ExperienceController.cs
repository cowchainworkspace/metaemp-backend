using MetaEmp.Api.Abstractions;
using MetaEmp.Application.Features.Public.Experiences;
using MetaEmp.Application.Features.Public.Experiences.All;
using MetaEmp.Application.Features.Public.Experiences.Create;
using MetaEmp.Application.Features.Public.Experiences.Delete;
using MetaEmp.Application.Features.Public.Experiences.One;
using MetaEmp.Application.Features.Public.Experiences.Update;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Areas.Public.Controllers;

public class ExperienceController : ApiController
{
    [HttpGet("{specialistId}")]
    public async Task<ExperienceResult[]> GetAll(Guid specialistId)
        => await Mediator.Send(new GetExperiencesRequest(specialistId));

    [HttpGet("{id}")]
    public async Task<ExperienceResult> GetOne([FromRoute] Guid id)
        => await Mediator.Send(new GetExperienceRequest(id));

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateExperienceRequest request)
    {
        var result = await Mediator.Send(request);
        return Created($"/v1/experience/{result.Id}", result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UpdateExperienceRequest request)
    {
        await Mediator.Send(request with {Id = id});
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        await Mediator.Send(new DeleteExperienceRequest(id));
        return NoContent();
    }
}