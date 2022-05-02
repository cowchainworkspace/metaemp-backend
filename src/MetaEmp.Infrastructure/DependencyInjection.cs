using MetaEmp.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace MetaEmp.Infrastructure;

public static class DependencyInjection
{
	public static void AddInfrastructure(this IServiceCollection services)
	{
		services.RegisterServicesFromAssembly("MetaEmp.Infrastructure");
	}
}