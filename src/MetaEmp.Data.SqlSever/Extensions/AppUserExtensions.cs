using MetaEmp.Data.SqlSever.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Data.SqlSever.Extensions;

public static class AppUserExtensions
{
	public static async Task<AppUser?> GetByLoginAsync(this IQueryable<AppUser> queryable, string login, CancellationToken cancel = default)
	{
		login = login.ToUpperInvariant();
		return await queryable
				.Where(e => e.NormalizedUserName == login || e.NormalizedEmail == login)
				.IncludeMany("Claims", "Roles.Role.Claims")
				.FirstOrDefaultAsync(cancel);
	}
}