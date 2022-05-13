using Mapster;
using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Specialists.Approvals.Create;

public class CreateSpecialistApprovalHandler : DbRequestHandler<CreateSpecialistApprovalRequest, Unit>
{
    public CreateSpecialistApprovalHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(CreateSpecialistApprovalRequest request)
    {
        //TODO: Add rights checking
        var specialistId = Guid.Parse("");

        if (await Context.Set<Company>().CountAsync(c => c.Id == request.CompanyId) == 0)
            throw new ValidationFailedException("CompanyId", "No such company");

        // Sets company and specialist name.
        // We do this in order to show information about the company/specialist, even if it is deleted.
        var experienceEntity = request.Adapt<Experience>();
        experienceEntity.CompanyName = (await Context.Set<Company>().FirstOrDefaultAsync(c => c.Id == request.CompanyId))!.Name;

        var specialist = await Context.Set<Specialist>().FirstOrDefaultAsync(s => s.Id == specialistId);
        experienceEntity.SpecialistFullname = $"{specialist!.Name} {specialist.Surname}";

        experienceEntity.Receiver = Receiver.Company;
        experienceEntity.Status = ApprovingStatus.Pending;

        await Context.Set<Experience>().AddAsync(experienceEntity);

        await Context.SaveChangesAsync();

        return Unit.Value;
    }
}