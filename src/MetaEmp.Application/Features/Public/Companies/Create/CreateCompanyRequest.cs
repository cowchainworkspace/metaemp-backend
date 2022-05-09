using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Create;

public class CreateCompanyRequest : IRequest<CompanyResult>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string WebSite { get; set; }
    public Socials Socials { get; set; }
    public string OwnerWallet { get; set; }
    public short EmployersCount { get; set; }    
}

