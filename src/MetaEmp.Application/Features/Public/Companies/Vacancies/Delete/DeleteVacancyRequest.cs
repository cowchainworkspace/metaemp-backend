using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Vacancies.Delete;

public record DeleteVacancyRequest(Guid Id) : IRequest;