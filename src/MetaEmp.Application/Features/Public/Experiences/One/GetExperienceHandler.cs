using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Extensions;


namespace MetaEmp.Application.Features.Public.Experiences.One;

public class GetExperienceHandler : DbRequestHandler<GetExperienceRequest, ExperienceResult>
{
    public GetExperienceHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<ExperienceResult> Handle(GetExperienceRequest request)
    {
        var experience = await Context.Set<Experience>().FirstOr404Async(e => e.Id == request.Id);

        return experience.Adapt<ExperienceResult>();
    }
}