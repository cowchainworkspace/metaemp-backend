using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Specialists.All;

public class GetSpecialistsHandler : DbRequestHandler<GetSpecialistsRequest, SpecialistResult[]>
{
    public GetSpecialistsHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<SpecialistResult[]> Handle(GetSpecialistsRequest request, CancellationToken cancel)
    {
        var specialists = await Context.Set<Specialist>().ToArrayAsync(cancel);

        HttpContext.SetCountHeader(await Context.Set<Specialist>().CountAsync(cancel));

        return specialists.Select(e => e.Adapt<SpecialistResult>()).ToArray();
    }
}