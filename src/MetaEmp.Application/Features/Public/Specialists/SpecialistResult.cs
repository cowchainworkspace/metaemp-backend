using MetaEmp.Application.Features.Public.Educations;
using MetaEmp.Application.Features.Public.Experiences;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Specialists;

public class SpecialistResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string? Title { get; set; }
    public string? UserStatus { get; set; }
    public string? About { get; set; }
    public List<string> ListOfSkills { get; set; }
    public DateTime Created { get; set; }

    public ApprovingStatus Status { get; set; }
    public string? RejectedReason { get; set; }
    public Guid UserId { get; set; }

    public ICollection<EducationResult>? Educations { get; set; }
    public ICollection<ExperienceResult>? Experiences { get; set; }
}