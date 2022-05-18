using Mapster;
using MetaEmp.Application.Abstractions;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Companies.Vacancies.Get;

public class GetVacancyHandler : DbRequestHandler<GetVacancyRequest, VacancyResult>
{
    public GetVacancyHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override async Task<VacancyResult> Handle(GetVacancyRequest request)
    {
        var vacancy = await Context.Set<Vacancy>().FirstOr404Async(v => v.Id == request.Id);

        return vacancy.Adapt<VacancyResult>();
    }
}