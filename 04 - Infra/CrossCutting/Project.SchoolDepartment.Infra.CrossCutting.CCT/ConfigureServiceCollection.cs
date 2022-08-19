using Microsoft.Extensions.DependencyInjection;
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
}
