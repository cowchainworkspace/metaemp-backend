using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Features.Public.Experiences;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Specialists.Approvals.Get;

public class GetSpecialistApprovalsHandler : DbRequestHandler<GetSpecialistApprovalsRequest, ExperienceResult[]>
{
    public GetSpecialistApprovalsHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<ExperienceResult[]> Handle(GetSpecialistApprovalsRequest request)
    {
        //TODO: Add rights checking
        var specialistId = Guid.Parse("");

        var approvals = await Context.Set<Experience>()
            .Where(e => e.SpecialistId == specialistId && e.Receiver == Receiver.Specialist &&
                        e.Status == ApprovingStatus.Pending)
            .ToArrayAsync();

        return approvals.Select(a => a.Adapt<ExperienceResult>()).ToArray();
    }
}