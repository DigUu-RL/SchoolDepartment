using Hangfire;
using Hangfire.MySql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;

namespace Project.SchoolDepartment.Infra.CrossCutting.CCT;

public static class ConfigureServiceCollection
{
	public static IServiceCollection ApplyDependencyInjection(this IServiceCollection services)
	{
		services.AddDbContext<Context>();

		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		return services;
	}

	public static IServiceCollection ApplyHangFire(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddHangfire(x =>
		{
			x.UseStorage(new MySqlStorage(new MySqlConnection(configuration.GetConnectionString("SchoolDepartment")), new MySqlStorageOptions()));
		}).AddHangfireServer();

		return services;
	}
}
