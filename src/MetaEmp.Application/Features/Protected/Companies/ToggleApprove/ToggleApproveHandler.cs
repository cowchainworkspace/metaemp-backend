using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Protected.Companies.ToggleApprove;

public class ToggleApproveHandler : AuthorizedRequestHandler<ToggleApproveRequest, ToggleApproveResult>
{
    public ToggleApproveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<ToggleApproveResult> Handle(ToggleApproveRequest request)
    {
        var company = await Context.Set<Company>().FirstOr404Async(c => c.Id == request.Id);

        company.Approved = !company.Approved;

        await Context.SaveChangesAsync();

        return new();
    }
}