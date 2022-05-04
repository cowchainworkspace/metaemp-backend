using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.All;

public class GetCompaniesRequest : IRequest<CompanyResult[]>
{
}