using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.One;

public record GetCompanyRequest(Guid Id) : IRequest<CompanyResult>;