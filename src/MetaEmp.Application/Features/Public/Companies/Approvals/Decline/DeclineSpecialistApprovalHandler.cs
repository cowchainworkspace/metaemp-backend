using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Companies.Approvals.Decline;

public class DeclineSpecialistApprovalHandler : DbRequestHandler<DeclineSpecialistApprovalRequest, Unit>
{
    public DeclineSpecialistApprovalHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(DeclineSpecialistApprovalRequest request)
    {
        //TODO: Add rights checking
        var companyOwnerId = Guid.Parse("");

        var approval = await Context.Set<Experience>()
            .FirstOr404Async(e => e.Id == request.ExperienceId);
        
        if (approval.Status is ApprovingStatus.Active or ApprovingStatus.Rejected)
            throw new ValidationFailedException("Request already approved");
        if (approval.Company!.OwnerId != companyOwnerId || approval.Receiver != Receiver.Company)
            throw new ForbidException("You have no permissions to do this");
        
        approval.Status = ApprovingStatus.Rejected;
        approval.RejectedReason = request.Message;

        return Unit.Value;
    }
}