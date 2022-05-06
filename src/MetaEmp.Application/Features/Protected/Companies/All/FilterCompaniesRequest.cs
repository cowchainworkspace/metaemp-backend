using MediatR;
using MetaEmp.Application.Features.Public.Companies;

namespace MetaEmp.Application.Features.Protected.Companies.All;

public class FilterCompaniesRequest : IRequest<CompanyResult[]>
{
    public bool Approved { get; set; }
}