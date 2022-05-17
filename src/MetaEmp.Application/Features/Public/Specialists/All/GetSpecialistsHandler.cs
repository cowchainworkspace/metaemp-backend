using System.Linq.Dynamic.Core;
using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Specialists.All;

public class GetSpecialistsHandler : DbRequestHandler<FilterSpecialistsRequest, SpecialistResult[]>
{
    public GetSpecialistsHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<SpecialistResult[]> Handle(FilterSpecialistsRequest request, CancellationToken cancel)
    {
        var specialistsQuery = Context.Set<Specialist>().AsQueryable();

        if (request.Name is not null)
            specialistsQuery = specialistsQuery.Where("(Name + \" \" + Surname).Contains(@0)", request.Name);
                
        if (request.OrderBy is not null)
            specialistsQuery = specialistsQuery.OrderBy(request.OrderBy);

        if (request.Status is not null)
            specialistsQuery = specialistsQuery.Where("Status == @0", request.Status);

        HttpContext.SetCountHeader(await specialistsQuery.CountAsync(cancel));

        return await specialistsQuery.Select(e => e.Adapt<SpecialistResult>()).ToArrayAsync(cancel);
    }
}