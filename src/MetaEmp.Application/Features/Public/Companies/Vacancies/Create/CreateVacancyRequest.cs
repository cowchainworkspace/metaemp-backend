using System.Text.Json.Serialization;
using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Vacancies.Create;

public record CreateVacancyRequest([property: JsonIgnore] Guid CompanyId,
    string Title,
    string[] Requirements,
    string Description) : IRequest<VacancyResult>;