using Mapster;
using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Experiences.Update;

public class UpdateExperienceHandler : DbRequestHandler<UpdateExperienceRequest, Unit>
{
    public UpdateExperienceHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(UpdateExperienceRequest request)
    {
        var experience = await Context.Set<Experience>().FirstOr404Async(e => e.Id == request.Id);

        request.Adapt(experience);

        await Context.SaveChangesAsync();
        
        return Unit.Value;
    }
}