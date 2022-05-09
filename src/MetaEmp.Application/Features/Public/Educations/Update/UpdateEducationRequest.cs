using System.Text.Json.Serialization;
using MediatR;

namespace MetaEmp.Application.Features.Public.Educations.Update;

public record UpdateEducationRequest : IRequest<Unit>
{
    [JsonIgnore] 
    public Guid Id { get; set; }
    public string UniversityName { get; set; } = default!;
    public string Degree { get; set; } = default!;
    public string Specialization { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string AdditionalInfo { get; set; } = default!;
}