using System.ComponentModel.DataAnnotations.Schema;
using MetaEmp.Core.Abstractions.Entities;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Data.SqlSever.Entities.CoursesEntities;

[Table("CourseProfiles")]
public class CourseProfile : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string RoadsJson { get; set; } = default!;
    public ApprovingStatus Status { get; set; }
    
    public DateTime Created { get; set; } = DateTime.UtcNow;
    
    #region User

    public Guid UserId { get; set; }
    public virtual AppUser? User { get; set; }

    #endregion
    
    #region Logo

    public Guid? LogoId { get; set; }
    public virtual File? Logo { get; set; }

    #endregion
}