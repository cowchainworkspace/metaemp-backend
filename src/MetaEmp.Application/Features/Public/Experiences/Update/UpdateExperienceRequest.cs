using System.Text.Json.Serialization;
using MediatR;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Experiences.Update;

public record UpdateExperienceRequest : IRequest<Unit>
{
    [JsonIgnore] 
    public Guid Id { get; set; }
    public string Position { get; set; } = default!;
    public EmploymentType Type { get; set; }
    public string? CompanyName { get; set; }
    public string Location { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool CurrentlyWork { get; set; }
    public string? Description { get; set; }
    public Guid? CompanyId { get; set; }
}