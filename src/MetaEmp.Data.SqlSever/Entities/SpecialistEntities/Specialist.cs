using System.ComponentModel.DataAnnotations.Schema;
using MetaEmp.Core.Abstractions.Entities;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Data.SqlSever.Entities.SpecialistEntities;

[Table("Specialists")]
public class Specialist : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string? Title { get; set; }
    public string? UserStatus { get; set; }
    public string? About { get; set; }
    public string? ListOfSkillsJson { get; set; }
    
    public ApprovingStatus Status { get; set; }
    public string? RejectedReason { get; set; }
    
    public Guid UserId { get; set; }
    public virtual AppUser? User { get; set; }
    
    
    public virtual ICollection<Education>? Educations { get; set; }
    public virtual ICollection<Experience>? Experiences { get; set; }
}