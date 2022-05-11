using FluentValidation;
using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Specialists.Create;

public class CreateSpecialistHandler : DbRequestHandler<CreateSpecialistRequest, SpecialistResult>
{
    public CreateSpecialistHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<SpecialistResult> Handle(CreateSpecialistRequest request)
    {
        var userId = Guid.Parse("09ABD51D-B0AB-4395-7681-08DA32A20000");

        if (await Context.Set<Specialist>().CountAsync(s => s.UserId == userId) > 0)
            throw new ValidationFailedException("Specialist profile for this user already exists");

        var specialist = request.Adapt<Specialist>();
        specialist.Status = ApprovingStatus.Pending;
        specialist.Created = DateTime.UtcNow;


        //TODO: add checking for userId
        specialist.UserId = userId;


        var createdEntity = await Context.Set<Specialist>().AddAsync(specialist);

        await Context.SaveChangesAsync();

        return createdEntity.Entity.Adapt<SpecialistResult>();
    }
}