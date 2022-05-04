using MetaEmp.Core.Enums;

namespace MetaEmp.Application.Features.Public.Auth.Check;

public record AuthCheckResult(
	bool UserExists,
	string? Username,
	AuthMethod PreferAuthMethod,
	IEnumerable<AuthMethod> AllowedAuthMethod
);