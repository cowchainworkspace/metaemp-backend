using MediatR;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Specialists.Approvals.Create;

public record CreateSpecialistApprovalRequest : IRequest<Experience>
{
    public Guid CompanyId { get; set; }

    public string Position { get; set; } = default!;
    public EmploymentType Type { get; set; }
    public string Location { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool CurrentlyWork { get; set; }
    public string? Description { get; set; }
}