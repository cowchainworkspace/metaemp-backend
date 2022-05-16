using MetaEmp.Application.Features.Public.Experiences;
using MetaEmp.Application.Features.Public.Specialists.Approvals.Complete;
using MetaEmp.Application.Features.Public.Specialists.Approvals.Create;
using MetaEmp.Application.Features.Public.Specialists.Approvals.Decline;
using MetaEmp.Application.Features.Public.Specialists.Approvals.Get;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Areas.Public.Controllers;

public partial class SpecialistController
{
    [HttpGet("approvals")]
    public async Task<ExperienceResult[]> GetAll()
        => await Mediator.Send(new GetSpecialistApprovalsRequest());

    [HttpPost("approvals")]
    public async Task<IActionResult> Create([FromBody] CreateSpecialistApprovalRequest request)
    {
        var result = await Mediator.Send(request);
        return CreatedAtAction(nameof(GetAll), result);
    }

    [HttpGet("approvals/complete/{id:guid}")]
    public async Task<IActionResult> Complete([FromRoute] Guid id)
    {
        await Mediator.Send(new CompleteCompanyApprovalRequest(id));
        return NoContent();
    }

    [HttpPost("approvals/decline/{id:guid}")]
    public async Task<IActionResult> Decline([FromRoute] Guid id, [FromBody] DeclineCompanyApprovalRequest request)
    {
        await Mediator.Send(request with {ExperienceId = id});
        return NoContent();
    }
}