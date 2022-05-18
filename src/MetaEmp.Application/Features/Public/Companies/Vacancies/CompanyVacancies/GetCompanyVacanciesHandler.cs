using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Application.Features.Public.Companies.Vacancies.CompanyVacancies;

public class GetCompanyVacanciesHandler : DbRequestHandler<GetCompanyVacanciesRequest, VacancyResult[]>
{
    public GetCompanyVacanciesHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<VacancyResult[]> Handle(GetCompanyVacanciesRequest request, CancellationToken cancel)
    {
        var vacancies = await Context.Set<Vacancy>().Where(v => v.CompanyId == request.CompanyId)
            .ProjectToType<VacancyResult>()
            .ToArrayAsync(cancel);

        return vacancies;
    }
}