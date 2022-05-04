using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Application.Features.Public.Companies;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Protected.Companies.All;

public class FilterCompaniesHandler : AuthorizedRequestHandler<FilterCompaniesRequest, CompanyResult[]>
{
    public FilterCompaniesHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<CompanyResult[]> Handle(FilterCompaniesRequest request, CancellationToken cancel)
    {
        //TODO: add checking for admin permissions


        var companies = await Context.Set<Company>()
            .Where(c => c.Approved == request.Approved)
            .ProjectToType<CompanyResult>()
            .ToArrayAsync(cancel);

        HttpContext.SetCountHeader(await Context.Set<Company>()
            .Where(c => c.Approved == request.Approved)
            .CountAsync(cancel));

        return companies;
    }
}