using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;

namespace MetaEmp.Application.Features.Public.Specialists.Delete;

public class DeleteSpecialistHandler : DbRequestHandler<DeleteSpecialistRequest, Unit>
{
    public DeleteSpecialistHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(DeleteSpecialistRequest request)
    {
        Context.Set<Specialist>().Remove(new Specialist {Id = request.Id});

        await Context.SaveChangesAsync();
        
        return Unit.Value;
    }
}