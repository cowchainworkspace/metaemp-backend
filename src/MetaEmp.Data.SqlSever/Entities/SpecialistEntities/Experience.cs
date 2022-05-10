using System.ComponentModel.DataAnnotations.Schema;
using MetaEmp.Core.Abstractions.Entities;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Data.SqlSever.Entities.SpecialistEntities;

[Table("Experiences")]
public class Experience : IEntity
{
    public Guid Id { get; set; }
    public string Position { get; set; } = default!;
    public EmploymentType Type { get; set; }
    public string CompanyName { get; set; } = default!;
    public string Location { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool CurrentlyWork { get; set; }
    public string? Description { get; set; }
    
    
    public Guid? CompanyId { get; set; }
    public virtual Company? Company { get; set; } 
    
    public Guid SpecialistId { get; set; }
    public virtual Specialist? Specialist { get; set; }
}