using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Protected.Specialists.SetStatus;

public class SetSpecialistStatusHandler : DbRequestHandler<SetSpecialistStatusRequest, Unit>
{
    public SetSpecialistStatusHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(SetSpecialistStatusRequest request)
    {
        var specialist = await Context.Set<Specialist>().FirstOr404Async(c => c.Id == request.Id);

        specialist.Status = request.Status;
        specialist.RejectedReason = request.Status == ApprovingStatus.Rejected ? request.RejectedMessage : null;

        await Context.SaveChangesAsync();

        return Unit.Value;
    }
}