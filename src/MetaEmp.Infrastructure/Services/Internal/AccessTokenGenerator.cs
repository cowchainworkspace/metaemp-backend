using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MetaEmp.Application.Models;
using MetaEmp.Application.Options;
using MetaEmp.Core.Abstractions.Context;
using MetaEmp.Core.Constants;
using MetaEmp.Core.DependencyInjection;
using MetaEmp.Data.SqlSever.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MetaEmp.Infrastructure.Services.Internal;

[Inject]
public class AccessTokenGenerator
{
	private readonly IDatabaseContext _database;
	private readonly JwtOptions _options;

	public AccessTokenGenerator(IOptions<JwtOptions> optionsAccessor, IDatabaseContext database)
	{
		_database = database;
		_options = optionsAccessor.Value;
	}

	public async Task<JwtToken> GenerateAsync(AppUser user, CancellationToken cancel = default)
	{
		DateTime expires = DateTime.UtcNow.Add(_options.AccessTokenLifetime);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(await GetUserClaimsAsync(user, cancel)),
			Expires = expires,
			SigningCredentials = new SigningCredentials(_options.Secret, SecurityAlgorithms.HmacSha256Signature),
			IssuedAt = DateTime.UtcNow,
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		SecurityToken jwt = tokenHandler.CreateToken(tokenDescriptor);

		return new JwtToken(tokenHandler.WriteToken(jwt), expires);
	}

	private async Task<IEnumerable<Claim>> GetUserClaimsAsync(AppUser user, CancellationToken cancel)
	{
		var claims = new List<Claim>
		{
			new(Claims.Id, user.Id.ToString()),
			new(Claims.UserName, user.NormalizedUserName)
		};

		IEnumerable<string> roles = await GetUserRolesAsync(user.Id, cancel);

		claims.AddRange(roles.Select(role => new Claim(Claims.Role, role)));

		return claims;
	}
	
	public Task<List<string>> GetUserRolesAsync(Guid userId, CancellationToken cancel)
	{
		return (from u in _database.Set<AppUserRole>()
			where u.UserId == userId
			join r in _database.Set<AppRole>() on u.RoleId equals r.Id
			select r.Name).ToListAsync(cancel);
	}
}