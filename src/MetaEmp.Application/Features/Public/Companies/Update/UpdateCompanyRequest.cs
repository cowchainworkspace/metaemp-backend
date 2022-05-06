using System.Text.Json.Serialization;
using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Update;

public record UpdateCompanyRequest : IRequest<UpdateCompanyResult>
{
    [JsonIgnore]
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string WebSite { get; set; }
    public Socials Socials { get; set; }
    public string Logo { get; set; }
    public short EmployersCount { get; set; }
    public Guid OwnerId { get; set; }
}