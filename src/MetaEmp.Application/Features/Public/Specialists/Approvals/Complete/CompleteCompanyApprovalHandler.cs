using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Specialists.Approvals.Complete;

public class CompleteCompanyApprovalHandler : DbRequestHandler<CompleteCompanyApprovalRequest, Unit>
{
    public CompleteCompanyApprovalHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(CompleteCompanyApprovalRequest request)
    {
        //TODO: Add rights checking
        var specialistId = Guid.Parse("");

        var approval = await Context.Set<Experience>()
            .FirstOr404Async(a => a.Id == request.ExperienceId);

        if (approval.Status is ApprovingStatus.Active or ApprovingStatus.Rejected)
            throw new ValidationFailedException("Request already approved");
        if (approval.SpecialistId != specialistId || approval.Receiver != Receiver.Specialist)
            throw new ForbidException("You have no permissions to do this");

        approval.Status = ApprovingStatus.Active;

        await Context.SaveChangesAsync();

        return Unit.Value;
    }
}