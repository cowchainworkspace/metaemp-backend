using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.Workers.Remove;

public class RemoveCompanyWorkerHandler : AuthorizedRequestHandler<RemoveCompanyWorkerRequest, Unit>
{
    public RemoveCompanyWorkerHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(RemoveCompanyWorkerRequest request)
    {
        //TODO: Replace
        var companyOwnerId = Guid.Parse("");

        var worker = await Context.Set<CompanyWorker>()
            .Include(cw => cw.Company)
            .FirstOr404Async(cw =>
                cw.CompanyId == request.CompanyId
                && cw.SpecialistId == request.SpecialistId);

        if (worker.Company!.OwnerId != companyOwnerId)
            throw new PermissionsException();

        Context.Set<CompanyWorker>().Remove(worker);

        await Context.SaveChangesAsync();
        
        return Unit.Value;
    }
}