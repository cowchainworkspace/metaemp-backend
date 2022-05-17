using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.Workers.Get;

public class GetCompanyWorkersHandler : AuthorizedRequestHandler<GetCompanyWorkersRequest, CompanyWorkerResult[]>
{
    public GetCompanyWorkersHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<CompanyWorkerResult[]> Handle(GetCompanyWorkersRequest request, CancellationToken cancel)
    {
        //TODO: Replace
        var companyOwnerId = Guid.Parse("");

        if ((await Context.Set<Company>().FirstOr404Async(c => c.Id == request.CompanyId, cancel)).OwnerId !=
            companyOwnerId)
            throw new PermissionsException();

        var workers = await Context.Set<CompanyWorker>()
            .Where(cw => cw.CompanyId == request.CompanyId)
            .ProjectToType<CompanyWorkerResult>()
            .ToArrayAsync(cancel);

        return workers;
    }
}