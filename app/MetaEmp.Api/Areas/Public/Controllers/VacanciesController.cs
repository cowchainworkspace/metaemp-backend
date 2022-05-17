using MetaEmp.Api.Abstractions;
using MetaEmp.Application.Features.Public.Companies.Vacancies;
using MetaEmp.Application.Features.Public.Companies.Vacancies.CompanyVacancies;
using MetaEmp.Application.Features.Public.Companies.Vacancies.Create;
using MetaEmp.Application.Features.Public.Companies.Vacancies.Delete;
using MetaEmp.Application.Features.Public.Companies.Vacancies.Get;
using MetaEmp.Application.Features.Public.Companies.Vacancies.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Areas.Public.Controllers;

[AllowAnonymous]
public class VacanciesController : ApiController
{
    [HttpGet("{id:guid}")]
    public async Task<VacancyResult> GetVacancy([FromRoute] Guid id)
        => await Mediator.Send(new GetVacancyRequest(id));

    [HttpGet("{companyId:guid}")]
    public async Task<VacancyResult[]> GetCompanyVacancies([FromRoute] Guid companyId, CancellationToken cancel)
        => await Mediator.Send(new GetCompanyVacanciesRequest(companyId), cancel);

    [HttpPost("{companyId:guid}")]
    public async Task<IActionResult> CreateVacancy([FromRoute] Guid companyId, [FromBody] CreateVacancyRequest request)
    {
        var result = await Mediator.Send(request with {CompanyId = companyId});
        return CreatedAtAction(nameof(GetVacancy), new {id = result.Id}, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateVacancy([FromRoute] Guid id, [FromBody] UpdateVacancyRequest request)
    {
        await Mediator.Send(request with {Id = id});
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteVacancy([FromRoute] Guid id)
    {
        await Mediator.Send(new DeleteVacancyRequest(id));
        return NoContent();
    }
}