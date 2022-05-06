using MetaEmp.Core.Abstractions.Context;
using Microsoft.EntityFrameworkCore;

namespace MetaEmp.Data.SqlSever.Context;

public class SqlServerDbContextFactory : DbContextFactoryBase<SqlServerDbContext>
{
	public override string SelectedConnectionName => "LocalSqlServer";
	public override string SettingsPath => "../../app/MetaEmp.Api/appsettings.Secrets.json";


	public override SqlServerDbContext CreateDbContext(string[] args) => new(CreateContextOptions());


	public override void ConfigureContextOptions(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(ConnectionString,
			options => options.MigrationsAssembly(MigrationsAssembly));
	}
}