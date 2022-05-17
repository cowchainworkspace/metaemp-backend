using System.Text.Json.Serialization;
using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Workers.Get;

public record GetCompanyWorkersRequest([property: JsonIgnore] Guid CompanyId) : IRequest<CompanyWorkerResult[]>;