using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
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
        //TODO: Replace
        var specialistId = Guid.Parse("EEA3155D-607A-43EC-BA4D-08DA335A2F0D");

        var approvals = await Context.Set<Experience>()
            .Where(e => e.SpecialistId == specialistId && e.Receiver == Receiver.Specialist &&
                        e.Status == ApprovingStatus.Pending)
            .Include(e => e.Company)
            .ToArrayAsync();

        HttpContext.SetCountHeader(approvals.Length);

        return approvals.Select(a => a.Adapt<ExperienceResult>()).ToArray();
    }
}