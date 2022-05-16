using MetaEmp.Application.Features.Public.Companies.Approvals.Complete;
using MetaEmp.Application.Features.Public.Companies.Approvals.Create;
using MetaEmp.Application.Features.Public.Companies.Approvals.Decline;
using MetaEmp.Application.Features.Public.Companies.Approvals.Get;
using MetaEmp.Application.Features.Public.Experiences;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Areas.Public.Controllers;

public partial class CompaniesController
{
    [HttpGet("{id:guid}/approvals")]
    public async Task<ExperienceResult[]> GetAll([FromRoute] Guid id)
        => await Mediator.Send(new GetCompanyApprovalsRequest(id));

    [HttpPost("{id:guid}/approvals")]
    public async Task<IActionResult> Create([FromRoute] Guid id, [FromBody] CreateCompanyApprovalRequest request)
    {
        var result = await Mediator.Send(request with {CompanyId = id});
        return Created($"v1/companies/{result.Id}/approvals", result);
    }

    [HttpGet("approvals/complete/{id:guid}")]
    public async Task<IActionResult> Complete([FromRoute] Guid id)
    {
        await Mediator.Send(new CompleteSpecialistApprovalRequest(id));
        return NoContent();
    }

    [HttpPost("approvals/decline/{id:guid}")]
    public async Task<IActionResult> Decline([FromRoute] Guid id, [FromBody] DeclineSpecialistApprovalRequest request)
    {
        await Mediator.Send(request with {ExperienceId = id});
        return NoContent();
    }
}