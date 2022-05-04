namespace MetaEmp.Application.Features.Companies;

public class CompanyResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string WebSite { get; set; }
    public Socials Socials { get; set; }
    public string Logo { get; set; }
    public short EmployersCount { get; set; }
    public Guid OwnerId { get; set; }
}