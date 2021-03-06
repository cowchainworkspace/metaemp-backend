using MetaEmp.Api.Abstractions;
using MetaEmp.Application.Features.Protected.Companies.All;
using MetaEmp.Application.Features.Protected.Companies.ToggleApprove;
using MetaEmp.Application.Features.Public.Companies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Areas.Protected.Controllers;

public class CompaniesController : ProtectedController
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<CompanyResult[]> FilterCompanies(FilterCompaniesRequest request, CancellationToken cancel)
        => await Mediator.Send(request, cancel);

    [HttpPost("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> SetStatus([FromRoute] Guid id, [FromBody] SetCompanyStatusRequest request)
    {
        await Mediator.Send(request with {Id = id});
        return NoContent();
    }
}