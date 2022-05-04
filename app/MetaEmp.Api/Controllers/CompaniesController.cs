using MetaEmp.Api.Abstractions;
using MetaEmp.Api.Attributes;
using MetaEmp.Application.Features.Companies;
using MetaEmp.Application.Features.Companies.All;
using MetaEmp.Application.Features.Companies.Create;
using MetaEmp.Application.Features.Companies.Delete;
using MetaEmp.Application.Features.Companies.Logo;
using MetaEmp.Application.Features.Companies.One;
using MetaEmp.Application.Features.Companies.Update;
using MetaEmp.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Controllers;

public class CompaniesController : ApiController
{
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<CompanyResult> GetCompany(Guid id)
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

    [HttpPost("{id:guid}/logo")]
    [AllowAnonymous]
    public async Task<UploadCompanyLogoResult> UploadCompanyLogo([FromRoute] Guid id, IFormFile file)
        => await Mediator.Send(new UploadCompanyLogoRequest {CompanyId = id, File = file});
}