using MetaEmp.Api.Abstractions;
using MetaEmp.Application.Features.Protected.Specialists.All;
using MetaEmp.Application.Features.Protected.Specialists.SetStatus;
using MetaEmp.Application.Features.Public.Specialists;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Areas.Protected.Controllers;

public class SpecialistController : ProtectedController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<SpecialistResult[]> FilterSpecialists(FilterSpecialistsRequest request, CancellationToken cancel)
        => await Mediator.Send(request, cancel);

    [HttpPost("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> SetStatus([FromRoute] Guid id, [FromBody] SetSpecialistStatusRequest request)
    {
        await Mediator.Send(request with {Id = id});
        return NoContent();
    }
}