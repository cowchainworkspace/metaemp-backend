using Mapster;
using MediatR;
using MetaEmp.Core.Abstractions.Context;
using MetaEmp.Data.SqlSever.Entities;
using MetaEmp.Data.SqlSever.Extensions;

namespace MetaEmp.Application.Features.Users.GetByUsername;

internal class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, User>
{
	private readonly IDatabaseContext _database;
	public GetUserByUsernameHandler(IDatabaseContext database) => _database = database;


	public async Task<User> Handle(GetUserByUsernameQuery query, CancellationToken cancel)
	{
		var user = await _database.Set<AppUser>().Where(u => u.UserName == query.Username).FirstOr404Async(cancel);
		return user.Adapt<User>();
	}
}