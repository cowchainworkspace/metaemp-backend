using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Application.Features.Public.Experiences;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using MetaEmp.Data.SqlSever.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace MetaEmp.Application.Features.Public.Companies.Approvals.Get;

public class GetCompanyApprovalsHandler : DbRequestHandler<GetCompanyApprovalsRequest, ExperienceResult[]>
{
    public GetCompanyApprovalsHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<ExperienceResult[]> Handle(GetCompanyApprovalsRequest request)
    {
        //TODO: Replace
        var companyOwnerId = Guid.Parse("09ABD51D-B0AB-4395-7681-08DA32A20000");
        if ((await Context.Set<Company>().FirstOr404Async(c => c.Id == request.CompanyId)).OwnerId != companyOwnerId)
            throw new PermissionsException();

        var approvals = await Context.Set<Experience>()
            .Where(e => e.CompanyId == request.CompanyId && e.Receiver == Receiver.Company &&
                        e.Status == ApprovingStatus.Pending)
            .Include(e => e.Company)
            .ToArrayAsync();
        
        HttpContext.SetCountHeader(approvals.Length);

        return approvals.Select(a => a.Adapt<ExperienceResult>()).ToArray();
    }
}