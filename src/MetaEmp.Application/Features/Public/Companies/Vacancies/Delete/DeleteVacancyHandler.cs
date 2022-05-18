using MediatR;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.Vacancies.Delete;

public class DeleteVacancyHandler : AuthorizedRequestHandler<DeleteVacancyRequest, Unit>
{
    public DeleteVacancyHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<Unit> Handle(DeleteVacancyRequest request)
    {
        var userId = Guid.Parse("");
        var specialist = await Context.Set<Specialist>().FirstOr404Async(s => s.UserId == userId);
        var vacancy = await Context.Set<Vacancy>()
            .Include(v => v.Company)
            .FirstOr404Async(v => v.Id == request.Id);

        if (vacancy.Company!.GetHRs()?.FirstOrDefault(hr => hr.Id == specialist.Id) is null)
            throw new PermissionsException();

        Context.Set<Vacancy>().Remove(vacancy);

        await Context.SaveChangesAsync();

        return Unit.Value;
    }
}