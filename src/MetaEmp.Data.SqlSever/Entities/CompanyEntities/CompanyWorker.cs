using System.ComponentModel.DataAnnotations.Schema;
using MetaEmp.Core.Abstractions.Entities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Data.SqlSever.Entities.CompanyEntities;

[Table(nameof(CompanyWorker))]
public class CompanyWorker : IEntity
{
    public Guid Id { get; set; }
    public WorkerRole Role { get; set; }

    #region Company

    public Guid CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    #endregion

    #region Specialist

    public Guid SpecialistId { get; set; }
    public virtual Specialist? Specialist { get; set; }

    #endregion
}