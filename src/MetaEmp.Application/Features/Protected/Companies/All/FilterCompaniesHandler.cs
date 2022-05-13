using System.Linq.Dynamic.Core;
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

        var companiesQuery = Context.Set<Company>().AsQueryable();

        if (request.Name is not null)
            companiesQuery = companiesQuery.Where("Name.Contains(@0)", request.Name);
        if (request.Status is not null)
            companiesQuery = companiesQuery.Where("Status == @0", request.Status);
        if (request.SortFilter is not null)
            companiesQuery = companiesQuery.OrderBy(request.SortFilter);
        HttpContext.SetCountHeader(await companiesQuery.CountAsync(cancel));

        var result = await companiesQuery.ProjectToType<CompanyResult>()
            .ToArrayAsync(cancel);

        return result;
    }
}