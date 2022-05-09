using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Educations.All;

public class GetEducationsHandler : DbRequestHandler<GetEducationsRequest, EducationResult[]>
{
    public GetEducationsHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<EducationResult[]> Handle(GetEducationsRequest request, CancellationToken cancel)
    {
        var educations = await Context.Set<Education>()
            .Where(e => e.SpecialistId == request.SpecialistId)
            .ToArrayAsync(cancel);

        HttpContext.SetCountHeader(await Context.Set<Education>()
            .Where(e => e.SpecialistId == request.SpecialistId)
            .CountAsync(cancel));

        return educations.Select(e => e.Adapt<EducationResult>()).ToArray();
    }
}