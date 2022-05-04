using MediatR;

namespace MetaEmp.Application.Features.Companies.Delete;

public record DeleteCompanyRequest(Guid CompanyId) : IRequest<DeleteCompanyResult>;

    
