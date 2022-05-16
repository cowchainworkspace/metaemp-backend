using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using MetaEmp.Data.SqlSever.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.Approvals.Decline;

public class DeclineSpecialistApprovalHandler : DbRequestHandler<DeclineSpecialistApprovalRequest, Unit>
{
    public DeclineSpecialistApprovalHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(DeclineSpecialistApprovalRequest request)
    {
        //TODO: Replace
        var companyOwnerId = Guid.Parse("09ABD51D-B0AB-4395-7681-08DA32A20000");

        var approval = await Context.Set<Experience>()
            .Include(e => e.Company)
            .FirstOr404Async(e => e.Id == request.ExperienceId);
        
        if (approval.Status is ApprovingStatus.Active or ApprovingStatus.Rejected)
            throw new ValidationFailedException("Request already approved");
        if (approval.Company!.OwnerId != companyOwnerId || approval.Receiver != Receiver.Company)
            throw new PermissionsException();
        
        approval.Status = ApprovingStatus.Rejected;
        approval.RejectedReason = request.Message;

        await Context.SaveChangesAsync();
        
        return Unit.Value;
    }
}