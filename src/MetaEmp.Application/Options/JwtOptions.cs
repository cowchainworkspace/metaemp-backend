using Microsoft.IdentityModel.Tokens;

namespace MetaEmp.Application.Options;

public class JwtOptions
{
	public SecurityKey? Secret { get; set; }
	public TimeSpan AccessTokenLifetime { get; set; }
	public TimeSpan RefreshTokenLifetime { get; set; }
}