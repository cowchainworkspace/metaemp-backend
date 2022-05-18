namespace MetaEmp.Application.Features.Public.Companies.Vacancies;

public class VacancyResult
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string[] Requirements { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Guid CompanyId { get; set; }
}