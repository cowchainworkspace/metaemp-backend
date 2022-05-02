﻿using MetaEmp.Core.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace MetaEmp.Data.SqlSever.Entities;

public class AppUserRole : IdentityUserRole<long>, IEntity
{
	public override long UserId { get; set; }
	public override long RoleId { get; set; }


	public virtual AppUser? User { get; set; }
	public virtual AppRole? Role { get; set; }
}