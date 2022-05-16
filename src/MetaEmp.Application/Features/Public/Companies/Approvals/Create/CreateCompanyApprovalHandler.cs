using Mapster;
using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using MetaEmp.Data.SqlSever.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.Approvals.Create;

public class CreateCompanyApprovalHandler : DbRequestHandler<CreateCompanyApprovalRequest, Experience>
{
    public CreateCompanyApprovalHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Experience> Handle(CreateCompanyApprovalRequest request)
    {
        //TODO: Replace
        var companyOwnerId = Guid.Parse("09ABD51D-B0AB-4395-7681-08DA32A20000");

        if ((await Context.Set<Company>().FirstOr404Async(c => c.Id == request.CompanyId)).OwnerId != companyOwnerId)
            throw new PermissionsException();
        if (await Context.Set<Specialist>().CountAsync(c => c.Id == request.SpecialistId) == 0)
            throw new ValidationFailedException("SpecialistId", "No such specialist");


        // Sets company and specialist name.
        // We do this in order to show information about the company/specialist, even if it is deleted.
        var experienceEntity = request.Adapt<Experience>();
        experienceEntity.CompanyName =
            (await Context.Set<Company>().FirstOrDefaultAsync(c => c.Id == request.CompanyId))!.Name;

        var specialist = await Context.Set<Specialist>().FirstOrDefaultAsync(s => s.Id == request.SpecialistId);
        experienceEntity.SpecialistFullname = $"{specialist!.Name} {specialist.Surname}";

        experienceEntity.Receiver = Receiver.Specialist;
        experienceEntity.Status = ApprovingStatus.Pending;

        var createdEntity = await Context.Set<Experience>().AddAsync(experienceEntity);

        await Context.SaveChangesAsync();

        return createdEntity.Entity;
    }
}