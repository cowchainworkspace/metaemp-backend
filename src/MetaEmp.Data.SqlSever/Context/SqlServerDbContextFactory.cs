using MetaEmp.Core.Abstractions.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace MetaEmp.Data.SqlSever.Context;

public class SqlServerDbContextFactory : DbContextFactoryBase<SqlServerDbContext>
{
	public override string SelectedConnectionName => "LocalSqlServer";
	public override string SettingsPath => "../../app/CleanTemplate.Web.API/appsettings.json";


	public override SqlServerDbContext CreateDbContext(string[] args) => new(CreateContextOptions());


	public override void ConfigureContextOptions(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(ConnectionString,
			options => options.MigrationsAssembly(MigrationsAssembly));
	}
}