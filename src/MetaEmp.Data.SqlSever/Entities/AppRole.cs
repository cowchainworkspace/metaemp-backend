using MetaEmp.Core.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace MetaEmp.Data.SqlSever.Entities;

public class AppRole : IdentityRole<Guid>, IEntity
{
	public override Guid Id { get; set; }
	public override string Name { get; set; } = default!;
	public override string NormalizedName { get; set; } = default!;
	public override string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();


	public virtual ICollection<AppUserRole>? Users { get; set; }
}