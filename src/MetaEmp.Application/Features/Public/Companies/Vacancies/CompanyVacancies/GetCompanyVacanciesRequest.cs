using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Vacancies.CompanyVacancies;

public record GetCompanyVacanciesRequest(Guid CompanyId) : IRequest<VacancyResult[]>;