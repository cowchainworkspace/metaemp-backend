using MediatR;
using MetaEmp.Core.Abstractions.Context;
using MetaEmp.Core.Enums;
using MetaEmp.Data.SqlSever.Entities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Public.Auth.Check;

internal class AuthCheckHandler : IRequestHandler<AuthCheckRequest, AuthCheckResult>
{
	private readonly IDatabaseContext _database;
	
	public AuthCheckHandler(IDatabaseContext database)
	{
		_database = database;
	}


	public async Task<AuthCheckResult> Handle(AuthCheckRequest request, CancellationToken cancel)
	{
		var user = await _database.Set<AppUser>().GetByLoginAsync(request.Login, cancel: cancel);
		var authMethods = GetUserAuthMethods(user);

		return new AuthCheckResult(
			UserExists: user is not null,
			Username: user?.UserName ?? request.Login,
			PreferAuthMethod: SwitchPreferAuthMethod(user, authMethods),
			AllowedAuthMethod: authMethods
		);
	}


	private static IReadOnlyList<AuthMethod> GetUserAuthMethods(AppUser? user)
	{
		if (user is null)
			return new List<AuthMethod> { AuthMethod.Register };

		var authMethods = new List<AuthMethod>();

		if (!string.IsNullOrEmpty(user.PasswordHash))
			authMethods.Add(AuthMethod.Password);

		return authMethods;
	}

	private static AuthMethod SwitchPreferAuthMethod(AppUser? user, IReadOnlyList<AuthMethod> authMethods)
	{
		if (user is null || authMethods.Contains(AuthMethod.Register))
			return AuthMethod.Register;

		return AuthMethod.Password;
	}
}