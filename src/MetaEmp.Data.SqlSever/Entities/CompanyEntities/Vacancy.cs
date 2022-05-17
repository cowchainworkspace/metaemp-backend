using MetaEmp.Core.Abstractions.Entities;

namespace MetaEmp.Data.SqlSever.Entities.CompanyEntities;

public class Vacancy : IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string RequirementsJson { get; set; } = default!;
    public string Description { get; set; } = default!;

    #region Company

    public Guid CompanyId { get; set; }
    public virtual Company? Company { get; set; }

    #endregion
}