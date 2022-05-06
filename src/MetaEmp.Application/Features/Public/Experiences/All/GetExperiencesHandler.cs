using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Experiences.All;

public class GetExperiencesHandler : DbRequestHandler<GetExperiencesRequest, ExperienceResult[]>
{
    public GetExperiencesHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<ExperienceResult[]> Handle(GetExperiencesRequest request, CancellationToken cancel)
    {
        var experiences = await Context.Set<Experience>()
            .Where(e => e.SpecialistId == request.SpecialistId)
            .ToArrayAsync(cancel);

        HttpContext.SetCountHeader(await Context.Set<Experience>()
            .Where(e => e.SpecialistId == request.SpecialistId)
            .CountAsync(cancel));

        return experiences.Select(e => e.Adapt<ExperienceResult>()).ToArray();
    }
}