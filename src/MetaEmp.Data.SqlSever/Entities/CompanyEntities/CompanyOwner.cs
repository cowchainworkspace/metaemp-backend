using System.ComponentModel.DataAnnotations.Schema;
using MetaEmp.Core.Abstractions.Entities;

namespace MetaEmp.Data.SqlSever.Entities.CompanyEntities;

[Table("CompanyOwners")]
public class CompanyOwner : IEntity
{
    public Guid Id { get; set; }

    #region User

    public Guid UserId { get; set; }
    public virtual AppUser? User { get; set; }

    #endregion

    public virtual ICollection<Company>? Companies { get; set; }
}