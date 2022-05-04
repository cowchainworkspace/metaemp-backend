using MetaEmp.Core.Abstractions.Entities;

namespace MetaEmp.Data.SqlSever.Entities.CompanyEntities;

public class Company : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string WebSite { get; set; }
    public string Socials { get; set; }
    public string? Logo { get; set; }
    public short EmployersCount { get; set; }

    #region Owner
    
    public Guid OwnerId { get; set; }
    public AppUser Owner { get; set; }
    
    #endregion
}