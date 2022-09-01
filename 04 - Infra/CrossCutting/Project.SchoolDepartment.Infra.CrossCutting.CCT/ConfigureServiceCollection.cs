using Hangfire;
using Hangfire.MySql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Application.Services;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Services;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

namespace Project.SchoolDepartment.Infra.CrossCutting.CCT;

public static class ConfigureServiceCollection
{
	public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<Context>();

		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		// configuring Hangfire
		var storage = new MySqlStorage(configuration.GetConnectionString("HangfireConnection"), new MySqlStorageOptions());

		services.AddHangfire(x =>
		{
			x.UseSerializerSettings(new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
			});

			x.UseStorage(storage);
		}).AddHangfireServer();

		JobStorage.Current = storage;

		services.AddScoped(typeof(IApplicationAlunoService), typeof(ApplicationAlunoService));
		services.AddScoped(typeof(IDomainAlunoService), typeof(DomainAlunoService));
		services.AddScoped(typeof(IAlunoRepository), typeof(AlunoRepository));

		return services;
	}
}
