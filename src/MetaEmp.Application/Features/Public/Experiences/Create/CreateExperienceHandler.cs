using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;

namespace MetaEmp.Application.Features.Public.Experiences.Create;

public class CreateExperienceHandler : DbRequestHandler<CreateExperienceRequest, ExperienceResult>
{
    public CreateExperienceHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<ExperienceResult> Handle(CreateExperienceRequest request)
    {
        var createdEntity = await Context.Set<Experience>().AddAsync(request.Adapt<Experience>());

        await Context.SaveChangesAsync();

        return createdEntity.Entity.Adapt<ExperienceResult>();
    }
}