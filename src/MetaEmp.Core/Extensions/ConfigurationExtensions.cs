using Microsoft.Extensions.Configuration;

namespace MetaEmp.Core.Extensions;

public static class ConfigurationExtensions
{
	public static bool IsTesting(this IConfiguration configuration)
	{
		return configuration["TestingMode"] == "true";
	}
}