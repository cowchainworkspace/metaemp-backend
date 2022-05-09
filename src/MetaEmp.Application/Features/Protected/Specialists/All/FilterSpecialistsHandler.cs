using System.Linq.Dynamic.Core;
using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Application.Features.Public.Specialists;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Protected.Specialists.All;

public class FilterSpecialistsHandler : DbRequestHandler<FilterSpecialistsRequest, SpecialistResult[]>
{
    public FilterSpecialistsHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<SpecialistResult[]> Handle(FilterSpecialistsRequest request, CancellationToken cancel)
    {
        var specialistsQuery = Context.Set<Specialist>().AsQueryable();

        if (request.Name is not null)
            specialistsQuery =
                specialistsQuery.Where(s => (s.Name + " " + s.Surname).ToLower().Contains(request.Name.ToLower()));

        if (request.Status is not null)
            specialistsQuery = specialistsQuery.Where("Status == @0", request.Status);
        if (request.SortFilter is not null)
            specialistsQuery = specialistsQuery.OrderBy(request.SortFilter);

        HttpContext.SetCountHeader(await specialistsQuery.CountAsync(cancel));

        var result = await specialistsQuery.ProjectToType<SpecialistResult>()
            .ToArrayAsync(cancel);

        return result;
    }
}