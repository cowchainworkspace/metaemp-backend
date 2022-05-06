using Mapster;
using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Educations.Update;

public class UpdateEducationHandler : DbRequestHandler<UpdateEducationRequest, Unit>
{
    public UpdateEducationHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(UpdateEducationRequest request)
    {
        var experience = await Context.Set<Experience>().FirstOr404Async(e => e.Id == request.Id);

        request.Adapt(experience);

        await Context.SaveChangesAsync();
        
        return Unit.Value;
    }
}