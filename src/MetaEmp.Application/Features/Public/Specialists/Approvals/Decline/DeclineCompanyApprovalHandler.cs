using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Specialists.Approvals.Decline;

public class DeclineCompanyApprovalHandler : DbRequestHandler<DeclineCompanyApprovalRequest, Unit>
{
    public DeclineCompanyApprovalHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(DeclineCompanyApprovalRequest request)
    {
        //TODO: Replace
        var specialistId = Guid.Parse("EEA3155D-607A-43EC-BA4D-08DA335A2F0D");

        var approval = await Context.Set<Experience>()
            .FirstOr404Async(e => e.Id == request.ExperienceId);
        
        if (approval.Status is ApprovingStatus.Active or ApprovingStatus.Rejected)
            throw new ValidationFailedException("Request already approved");
        if (approval.SpecialistId != specialistId || approval.Receiver != Receiver.Specialist)
            throw new PermissionsException();

        approval.Status = ApprovingStatus.Rejected;
        approval.RejectedReason = request.Message;

        await Context.SaveChangesAsync();
        return Unit.Value;
    }
}