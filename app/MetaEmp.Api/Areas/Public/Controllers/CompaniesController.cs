using MetaEmp.Api.Abstractions;
using MetaEmp.Application.Features.Public.Companies;
using MetaEmp.Application.Features.Public.Companies.All;
using MetaEmp.Application.Features.Public.Companies.Create;
using MetaEmp.Application.Features.Public.Companies.Delete;
using MetaEmp.Application.Features.Public.Companies.One;
using MetaEmp.Application.Features.Public.Companies.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Areas.Public.Controllers;

public class CompaniesController : ApiController
{
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<CompanyResult> GetCompany([FromRoute] Guid id)
        => await Mediator.Send(new GetCompanyRequest(id));

    [HttpGet]
    [AllowAnonymous]
    // [ResponseCache(Duration = CacheDurations.Default)]
    public async Task<CompanyResult[]> GetCompanies(CancellationToken cancel)
        => await Mediator.Send(new GetCompaniesRequest(), cancel);

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<CompanyResult>> CreateCompany([FromBody] CreateCompanyRequest request)
    {
        var result = await Mediator.Send(request);
        return Created($"/v1/companies/{result.Id}", result);
    }

    [HttpPut("{id:guid}")]
    [AllowAnonymous]
    public async Task<StatusCodeResult> UpdateCompany([FromRoute] Guid id,
        [FromBody] UpdateCompanyRequest request)
    {
        await Mediator.Send(request with {CompanyId = id});
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [AllowAnonymous]
    public async Task<StatusCodeResult> DeleteCompany(Guid id)
    {
        await Mediator.Send(new DeleteCompanyRequest(id));
        return NoContent();
    }
}