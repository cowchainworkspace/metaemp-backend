using HashidsNet;
using Mapster;
using MetaEmp.Application.Features.Users;
using MetaEmp.Data.SqlSever.Entities;

namespace MetaEmp.Application;

internal class MappingRegister : IRegister
{
	private readonly IHashids _hashids;

	public MappingRegister(IHashids hashids)
	{
		_hashids = hashids;
	}

	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<AppUser, User>()
				.Map(m => m.Id, s => _hashids.EncodeLong(s.Id))
				.Map(m => m.Username, s => s.UserName);
	}
}