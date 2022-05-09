using MetaEmp.Api.Abstractions;
using MetaEmp.Application.Features.Public.Specialists;
using MetaEmp.Application.Features.Public.Specialists.All;
using MetaEmp.Application.Features.Public.Specialists.Create;
using MetaEmp.Application.Features.Public.Specialists.Delete;
using MetaEmp.Application.Features.Public.Specialists.One;
using MetaEmp.Application.Features.Public.Specialists.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Areas.Public.Controllers;

[AllowAnonymous]
public class SpecialistController : ApiController
{
    [HttpGet]
    public async Task<SpecialistResult[]> GetAll()
        => await Mediator.Send(new GetSpecialistsRequest());

    [HttpGet("{id}")]
    public async Task<SpecialistResult> GetOne([FromRoute] Guid id)
        => await Mediator.Send(new GetSpecialistRequest(id));

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateSpecialistRequest request)
    {
        var result = await Mediator.Send(request);
        return Created($"/v1/Specialist/{result.Id}", result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSpecialistRequest request)
    {
        await Mediator.Send(request with {Id = id});
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        await Mediator.Send(new DeleteSpecialistRequest(id));
        return NoContent();
    }
}