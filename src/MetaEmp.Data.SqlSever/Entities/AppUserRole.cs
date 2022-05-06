using MetaEmp.Core.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace MetaEmp.Data.SqlSever.Entities;

public class AppUserRole : IdentityUserRole<Guid>, IEntity
{
	public override Guid UserId { get; set; }
	public override Guid RoleId { get; set; }


	public virtual AppUser? User { get; set; }
	public virtual AppRole? Role { get; set; }
}