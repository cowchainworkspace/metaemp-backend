namespace MetaEmp.Application.Features.Public.Companies;

public class CompanyResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string WebSite { get; set; } = default!;
    public Socials Socials { get; set; } = default!;
    public string LogoId { get; set; } = default!;
    public short EmployersCount { get; set; }
    public Guid OwnerId { get; set; }
    public bool Approved { get; set; }
}