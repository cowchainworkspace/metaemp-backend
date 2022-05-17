using Mapster;
using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.Workers.Add;

public class AddCompanyWorkerHandler : AuthorizedRequestHandler<AddCompanyWorkerRequest, CompanyWorkerResult>
{
    public AddCompanyWorkerHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<CompanyWorkerResult> Handle(AddCompanyWorkerRequest request)
    {
        //TODO: Replace
        var companyOwnerId = Guid.Parse("");

        var experience = await Context.Set<Experience>()
            .Include(e => e.Company)
            .FirstOr404Async(e =>
                e.CompanyId == request.CompanyId
                && e.SpecialistId == request.SpecialistId
                && e.CurrentlyWork);

        if (experience.Company!.OwnerId != companyOwnerId)
            throw new PermissionsException();

        var entity = new CompanyWorker();

        request.Adapt(entity);

        var createdEntity = await Context.Set<CompanyWorker>().AddAsync(entity);
        

        return createdEntity.Entity.Adapt<CompanyWorkerResult>();
    }
}