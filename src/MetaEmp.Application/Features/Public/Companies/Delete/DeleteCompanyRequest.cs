using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Delete;

public record DeleteCompanyRequest(Guid CompanyId) : IRequest<DeleteCompanyResult>;

    
