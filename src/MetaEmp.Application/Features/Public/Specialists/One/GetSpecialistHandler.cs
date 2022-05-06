using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Extensions;


namespace MetaEmp.Application.Features.Public.Specialists.One;

public class GetSpecialistHandler : DbRequestHandler<GetSpecialistRequest, SpecialistResult>
{
    public GetSpecialistHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<SpecialistResult> Handle(GetSpecialistRequest request)
    {
        var specialist = await Context.Set<Specialist>().FirstOr404Async(e => e.Id == request.Id);

        return specialist.Adapt<SpecialistResult>();
    }
}