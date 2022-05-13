using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Features.Public.Experiences;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.Approvals.Get;

public class GetCompanyApprovalsHandler : DbRequestHandler<GetCompanyApprovalsRequest, ExperienceResult[]>
{
    public GetCompanyApprovalsHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<ExperienceResult[]> Handle(GetCompanyApprovalsRequest request)
    {
        //TODO: Add rights checking
        var companyOwnerId = Guid.Parse("");

        var approvals = await Context.Set<Experience>()
            .Where(e => e.CompanyId == request.CompanyId && e.Receiver == Receiver.Company &&
                        e.Status == ApprovingStatus.Pending)
            .ToArrayAsync();

        return approvals.Select(a => a.Adapt<ExperienceResult>()).ToArray();
    }
}