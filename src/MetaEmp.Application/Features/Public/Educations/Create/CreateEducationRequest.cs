using MediatR;

namespace MetaEmp.Application.Features.Public.Educations.Create;

public record CreateEducationRequest : IRequest<EducationResult>
{
    public string UniversityName { get; set; } = default!;
    public string Degree { get; set; } = default!;
    public string Specialization { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string AdditionalInfo { get; set; } = default!;
}