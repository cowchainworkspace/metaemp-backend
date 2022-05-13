using MediatR;
using MetaEmp.Application.Features.Public.Experiences;

namespace MetaEmp.Application.Features.Public.Companies.Approvals.Get;

public record GetCompanyApprovalsRequest(Guid CompanyId) : IRequest<ExperienceResult[]>;