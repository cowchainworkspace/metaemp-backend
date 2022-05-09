using System.ComponentModel.DataAnnotations.Schema;
using MetaEmp.Core.Abstractions.Entities;

namespace MetaEmp.Data.SqlSever.Entities.SpecialistEntities;

[Table("Educations")]
public class Education : IEntity
{
    public Guid Id { get; set; }
    public string UniversityName { get; set; } = default!;
    public string Degree { get; set; } = default!;
    public string Specialization { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string AdditionalInfo { get; set; } = default!;
    
    public Guid SpecialistId { get; set; }
    public virtual Specialist? Specialist { get; set; }
}