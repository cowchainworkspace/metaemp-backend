using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;

namespace MetaEmp.Application.Features.Public.Experiences.Delete;

public class DeleteExperienceHandler : DbRequestHandler<DeleteExperienceRequest, Unit>
{
    public DeleteExperienceHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(DeleteExperienceRequest request)
    {
        Context.Set<Experience>().Remove(new Experience {Id = request.Id});

        await Context.SaveChangesAsync();
        
        return Unit.Value;
    }
}