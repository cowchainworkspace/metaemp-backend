using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;

namespace MetaEmp.Application.Features.Public.Educations.Delete;

public class DeleteEducationHandler : DbRequestHandler<DeleteEducationRequest, Unit>
{
    public DeleteEducationHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(DeleteEducationRequest request)
    {
        Context.Set<Education>().Remove(new Education {Id = request.Id});

        await Context.SaveChangesAsync();
        
        return Unit.Value;
    }
}