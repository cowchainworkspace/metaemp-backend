using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;

namespace MetaEmp.Application.Features.Public.Specialists.Create;

public class CreateSpecialistHandler : DbRequestHandler<CreateSpecialistRequest, SpecialistResult>
{
    public CreateSpecialistHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<SpecialistResult> Handle(CreateSpecialistRequest request)
    {
        var createdEntity = await Context.Set<Specialist>().AddAsync(request.Adapt<Specialist>());

        await Context.SaveChangesAsync();

        return createdEntity.Entity.Adapt<SpecialistResult>();
    }
}