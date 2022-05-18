using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Application.Extensions;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.Vacancies.Create;

public class CreateVacancyHandler : AuthorizedRequestHandler<CreateVacancyRequest, VacancyResult>
{
    public CreateVacancyHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<VacancyResult> Handle(CreateVacancyRequest request)
    {
        var userId = Guid.Parse("");
        var specialist = await Context.Set<Specialist>().FirstOr404Async(s => s.UserId == userId);
        var company = await Context.Set<Company>()
            .Include(c => c.Workers)
            .FirstOr404Async(c => c.Id == request.CompanyId);

        if (company.GetHRs()?.FirstOrDefault(hr => hr.Id == specialist.Id) is null)
            throw new PermissionsException();

        var createEntity = request.Adapt<Vacancy>();

        var createdEntity = await Context.Set<Vacancy>().AddAsync(createEntity);

        return createdEntity.Entity.Adapt<VacancyResult>();
    }
}