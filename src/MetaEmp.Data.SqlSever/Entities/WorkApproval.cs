using MetaEmp.Core.Abstractions.Entities;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Data.SqlSever.Entities;

public class WorkApproval : IEntity
{
    public Guid Id { get; set; }

    #region Company

    public Guid? CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    #endregion

    #region Specialist

    public Guid? SpecialistId { get; set; }
    public virtual Specialist? Specialist { get; set; }

    #endregion

    public Receiver Receiver { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
}