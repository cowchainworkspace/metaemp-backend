using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;

namespace MetaEmp.Application.Features.Public.Educations.Create;

public class CreateEducationHandler : DbRequestHandler<CreateEducationRequest, EducationResult>
{
    public CreateEducationHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<EducationResult> Handle(CreateEducationRequest request)
    {
        var createdEntity = await Context.Set<Education>().AddAsync(request.Adapt<Education>());

        await Context.SaveChangesAsync();

        return createdEntity.Entity.Adapt<EducationResult>();
    }
}