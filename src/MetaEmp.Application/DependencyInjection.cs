using System.Reflection;
using System.Text;
using FluentValidation.AspNetCore;
using Mapster;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using MetaEmp.Application.Options;
using MetaEmp.Core.Constants;
using MetaEmp.Core.DependencyInjection;
using MetaEmp.Data.SqlSever.Context;
using MetaEmp.Data.SqlSever.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;

namespace MetaEmp.Application;

public static class DependencyInjection
{
	public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
	{
		services.RegisterServicesFromAssembly("MetaEmp.Application");

		services.BindConfigurationOptions(configuration);
		services.RegisterMappings();

		services.AddCustomMediatR();
	}


	public static void ConfigureFluentValidation(FluentValidationMvcConfiguration options)
	{
		options.DisableDataAnnotationsValidation = true;
		options.ImplicitlyValidateChildProperties = true;
		options.ImplicitlyValidateRootCollectionElements = true;
	}

	private static void BindConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<JwtOptions>(options =>
		{
			options.Secret = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]));
			options.AccessTokenLifetime = TimeSpan.Parse(configuration["Jwt:AccessTokenLifetime"]);
			options.RefreshTokenLifetime = TimeSpan.Parse(configuration["Jwt:RefreshTokenLifetime"]);
		});

		services.Configure<LocalizationOptions>(configuration.GetSection("Localization"));
	}

	public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddIdentity<AppUser, AppRole>(configuration.GetRequiredSection("Identity").Bind)
				.AddEntityFrameworkStores<SqlServerDbContext>()
				.AddTokenProvider(TokenProviders.Default, typeof(EmailTokenProvider<AppUser>));

		services.Configure<PasswordHasherOptions>(option => option.IterationCount = 7000);
	}

	private static void RegisterMappings(this IServiceCollection services)
	{
		var register = new MappingRegister();

		register.Register(TypeAdapterConfig.GlobalSettings);
	}

	private static void AddCustomMediatR(this IServiceCollection services)
	{
		var assemblies = new[] { Assembly.GetExecutingAssembly() };

		services.AddMediatR(assemblies).AddFluentValidation(ConfigureFluentValidation);
		services.AddFluentValidation(assemblies);
	}
}