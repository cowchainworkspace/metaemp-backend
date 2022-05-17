using MetaEmp.Application.Features.Public.Companies.Workers;
using MetaEmp.Application.Features.Public.Companies.Workers.Add;
using MetaEmp.Application.Features.Public.Companies.Workers.Get;
using MetaEmp.Application.Features.Public.Companies.Workers.Remove;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Areas.Public.Controllers;

public partial class CompaniesController
{
    [HttpGet("{id:guid}/workers")]
    public async Task<CompanyWorkerResult[]> GetWorkers([FromRoute] Guid id, CancellationToken cancel)
        => await Mediator.Send(new GetCompanyWorkersRequest(id), cancel);


    [HttpPost("{id:guid}/workers")]
    public async Task<IActionResult> AddWorker([FromRoute] Guid id, [FromBody] AddCompanyWorkerRequest request)
    {
        var result = await Mediator.Send(request with {CompanyId = id});
        return CreatedAtAction(nameof(GetWorkers), result);
    }

    [HttpDelete("{id:guid}/workers/{specialistId:guid}")]
    public async Task<IActionResult> RemoveWorker([FromRoute] Guid id, [FromRoute] Guid specialistId)
    {
        await Mediator.Send(new RemoveCompanyWorkerRequest(id, specialistId));
        return NoContent();
    }
}