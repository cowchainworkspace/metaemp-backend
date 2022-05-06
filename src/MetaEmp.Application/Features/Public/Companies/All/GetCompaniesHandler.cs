using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.All;

public class GetCompaniesHandler : DbRequestHandler<GetCompaniesRequest, CompanyResult[]>
{
    public GetCompaniesHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<CompanyResult[]> Handle(GetCompaniesRequest request, CancellationToken cancel)
    {
        var companies = await Context.Set<Company>()
            .ProjectToType<CompanyResult>()
            .ToArrayAsync(cancel);

        HttpContext.SetCountHeader(await Context.Set<Company>().CountAsync(cancel));

        return companies;
    }
}