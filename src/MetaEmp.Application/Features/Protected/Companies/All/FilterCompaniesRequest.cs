using MediatR;
using MetaEmp.Application.Features.Public.Companies;
using MetaEmp.Data.SqlSever;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Protected.Companies.All;

public class FilterCompaniesRequest : IRequest<CompanyResult[]>
{
    public ApprovingStatus Status { get; set; }
}