using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Educations.One;

public class GetEducationHandler : DbRequestHandler<GetEducationRequest, EducationResult>
{
    public GetEducationHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<EducationResult> Handle(GetEducationRequest request)
    {
        var education = await Context.Set<Education>().FirstOr404Async(e => e.Id == request.Id);

        return education.Adapt<EducationResult>();
    }
}