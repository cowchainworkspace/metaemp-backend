using System.ComponentModel.DataAnnotations.Schema;
using MetaEmp.Core.Abstractions.Entities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Data.SqlSever.Entities.CompanyEntities;

[Table("Companies")]
public class Company : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string WebSite { get; set; } = default!;
    public string? Socials { get; set; } = default!;
    public short EmployersCount { get; set; }
    public string OwnerWallet { get; set; } = default!;
    public DateTime Created { get; set; }

    public ApprovingStatus Status { get; set; }
    public string? RejectedReason { get; set; }

    public virtual ICollection<Experience>? SpecialistExperiences { get; set; }

    #region Owner

    public Guid OwnerId { get; set; }
    public virtual AppUser? Owner { get; set; }

    #endregion

    #region Logo

    public Guid? LogoId { get; set; }
    public File? Logo { get; set; }

    #endregion
}