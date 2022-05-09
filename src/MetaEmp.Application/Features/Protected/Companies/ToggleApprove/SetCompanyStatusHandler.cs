using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Enums;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Protected.Companies.ToggleApprove;

public class SetCompanyStatusHandler : AuthorizedRequestHandler<SetCompanyStatusRequest, SetCompanyStatusResult>
{
    public SetCompanyStatusHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<SetCompanyStatusResult> Handle(SetCompanyStatusRequest request)
    {
        var company = await Context.Set<Company>().FirstOr404Async(c => c.Id == request.Id);

        company.Status = request.Status;
        company.RejectedReason = request.Status == ApprovingStatus.Rejected ? request.RejectedMessage : null;

        await Context.SaveChangesAsync();

        return new();
    }
}