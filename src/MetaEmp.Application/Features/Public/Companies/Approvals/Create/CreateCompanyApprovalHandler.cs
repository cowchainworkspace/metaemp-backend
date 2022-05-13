using Mapster;
using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.Approvals.Create;

public class CreateCompanyApprovalHandler : DbRequestHandler<CreateCompanyApprovalRequest, Unit>
{
    public CreateCompanyApprovalHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(CreateCompanyApprovalRequest request)
    {
        //TODO: Add rights checking
        var companyOwnerId = Guid.Parse("");

        if (await Context.Set<Specialist>().CountAsync(c => c.Id == request.SpecialistId) == 0)
            throw new ValidationFailedException("SpecialistId", "No such specialist");

        // Sets company and specialist name.
        // We do this in order to show information about the company/specialist, even if it is deleted.
        var experienceEntity = request.Adapt<Experience>();
        experienceEntity.CompanyName = (await Context.Set<Company>().FirstOrDefaultAsync(c => c.Id == request.CompanyId))!.Name;

        var specialist = await Context.Set<Specialist>().FirstOrDefaultAsync(s => s.Id == request.SpecialistId);
        experienceEntity.SpecialistFullname = $"{specialist!.Name} {specialist.Surname}";

        experienceEntity.Receiver = Receiver.Specialist;
        experienceEntity.Status = ApprovingStatus.Pending;

        await Context.Set<Experience>().AddAsync(experienceEntity);

        await Context.SaveChangesAsync();

        return Unit.Value;
    }
}