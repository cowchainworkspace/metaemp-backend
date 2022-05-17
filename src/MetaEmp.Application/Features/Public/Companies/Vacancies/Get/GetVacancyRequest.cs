using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Vacancies.Get;

public record GetVacancyRequest(Guid Id) : IRequest<VacancyResult>;