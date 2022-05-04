using MetaEmp.Core.Abstractions.Entities;

namespace MetaEmp.Data.SqlSever.Entities.CompanyEntities;

public class Company : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string WebSite { get; set; } = default!;
    public string Socials { get; set; } = default!;
    public short EmployersCount { get; set; }
    public bool Approved { get; set; }

    #region Owner

    public Guid OwnerId { get; set; }
    public AppUser Owner { get; set; }

    #endregion

    #region Logo

    public Guid? LogoId { get; set; }
    public File? Logo { get; set; }

    #endregion
}