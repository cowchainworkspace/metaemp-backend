using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using MetaEmp.Data.SqlSever.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.Approvals.Complete;

public class CompleteSpecialistApprovalHandler : DbRequestHandler<CompleteSpecialistApprovalRequest, Unit>
{
    public CompleteSpecialistApprovalHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(CompleteSpecialistApprovalRequest request)
    {
        //TODO: Replace
        var companyOwnerId = Guid.Parse("09ABD51D-B0AB-4395-7681-08DA32A20000");

        var approval = await Context.Set<Experience>()
            .Include(e => e.Company)
            .FirstOr404Async(a => a.Id == request.ExperienceId);
        
        if (approval.Status is ApprovingStatus.Active or ApprovingStatus.Rejected)
            throw new ValidationFailedException("Request already approved");
        if (approval.Company!.OwnerId != companyOwnerId || approval.Receiver != Receiver.Company)
            throw new PermissionsException();

        approval.Status = ApprovingStatus.Active;

        await Context.SaveChangesAsync();
        
        return Unit.Value;
    }
}