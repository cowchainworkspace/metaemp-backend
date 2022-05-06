using Mapster;
using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Specialists.Update;

public class UpdateSpecialistHandler : DbRequestHandler<UpdateSpecialistRequest, Unit>
{
    public UpdateSpecialistHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(UpdateSpecialistRequest request)
    {
        var specialist = await Context.Set<Specialist>().FirstOr404Async(e => e.Id == request.Id);

        request.Adapt(specialist);

        await Context.SaveChangesAsync();
        
        return Unit.Value;
    }
}