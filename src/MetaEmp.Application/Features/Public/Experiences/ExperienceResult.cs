using MetaEmp.Application.Features.Public.Companies;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Experiences;

public record ExperienceResult
{
    public Guid Id { get; set; }
    public string Position { get; set; } = default!;
    public EmploymentType Type { get; set; }
    public string? CompanyName { get; set; }
    public string Location { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool CurrentlyWork { get; set; }
    public string? Description { get; set; }
    public CompanyResult? Company { get; set; }
}