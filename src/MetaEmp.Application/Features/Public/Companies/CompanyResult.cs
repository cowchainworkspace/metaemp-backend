using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Companies;

public class CompanyResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string WebSite { get; set; } = default!;
    public Socials Socials { get; set; } = default!;
    public Guid? LogoId { get; set; } = default!;
    public short EmployersCount { get; set; }
    public string OwnerWallet { get; set; } = default!;
    public Guid OwnerId { get; set; }
    public DateTime Created { get; set; }
    public ApprovingStatus Status { get; set; }
    public string? RejectedReason { get; set; }
}