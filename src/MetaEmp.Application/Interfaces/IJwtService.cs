using MetaEmp.Application.Features.Public.Auth;
using MetaEmp.Data.SqlSever.Entities;

namespace MetaEmp.Application.Interfaces;

public interface IJwtService
{
	Task<AuthResult> GenerateAsync(AppUser user, CancellationToken cancel = default);
	Task<AuthResult> RefreshAsync(string refreshToken, CancellationToken cancel = default);
}