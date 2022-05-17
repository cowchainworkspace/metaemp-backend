using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Workers.Remove;

public record RemoveCompanyWorkerRequest(Guid CompanyId, Guid SpecialistId) : IRequest;