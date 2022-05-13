using System.ComponentModel.DataAnnotations.Schema;
using MetaEmp.Core.Abstractions.Entities;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.EducationEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;
using Microsoft.AspNetCore.Identity;

namespace MetaEmp.Data.SqlSever.Entities;

[Table("AppUsers")]
public class AppUser : IdentityUser<Guid>, IEntity
{
    public override Guid Id { get; set; }
    public override string UserName { get; set; } = default!;
    public override string NormalizedUserName { get; set; } = default!;
    public override string Email { get; set; } = default!;
    public override string NormalizedEmail { get; set; } = default!;
    public override bool EmailConfirmed { get; set; }
    public string? Description { get; set; }
    public override string? PasswordHash { get; set; }
    public override string SecurityStamp { get; set; } = default!;
    public override string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    public override string? PhoneNumber { get; set; }
    public override bool PhoneNumberConfirmed { get; set; }
    public override bool TwoFactorEnabled { get; set; }
    public override DateTimeOffset? LockoutEnd { get; set; }
    public override bool LockoutEnabled { get; set; }
    public override int AccessFailedCount { get; set; }
    public string WalletAddress { get; set; } = default!;
    public DateTime Registered { get; set; } = DateTime.UtcNow;


    #region Specialist

    public Guid SpecialistId { get; set; }
    public virtual Specialist? SpecialistProfile { get; set; }

    #endregion

    public virtual ICollection<CourseProfile>? CourseProfiles { get; set; }
    public virtual ICollection<Company>? Companies { get; set; }
    public virtual ICollection<AppUserRole>? Roles { get; set; }
    public virtual ICollection<AppRefreshToken>? RefreshTokens { get; set; }
}