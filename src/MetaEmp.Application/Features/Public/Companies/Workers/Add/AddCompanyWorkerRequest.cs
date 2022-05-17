using System.Text.Json.Serialization;
using MediatR;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Companies.Workers.Add;

public record AddCompanyWorkerRequest : IRequest<CompanyWorkerResult>
{
    public Guid SpecialistId { get; set; }
    [JsonIgnore]
    public Guid CompanyId { get; set; }
    public WorkerRole Role { get; set; }
}