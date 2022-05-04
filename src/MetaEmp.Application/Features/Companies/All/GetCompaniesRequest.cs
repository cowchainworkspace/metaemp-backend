using MediatR;
using MetaEmp.Application.Features.Companies.One;

namespace MetaEmp.Application.Features.Companies.All;

public class GetCompaniesRequest : IRequest<CompanyResult[]>
{
}