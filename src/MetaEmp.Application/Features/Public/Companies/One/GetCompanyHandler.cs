using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Companies.One;

public class GetCompanyHandler : DbRequestHandler<GetCompanyRequest, CompanyResult>
{
    public GetCompanyHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<CompanyResult> Handle(GetCompanyRequest request)
    {
        var company = await Context.Set<Company>()
            .FirstOr404Async(c => c.Id == request.Id);
        
        return company.Adapt<CompanyResult>();
    }
}