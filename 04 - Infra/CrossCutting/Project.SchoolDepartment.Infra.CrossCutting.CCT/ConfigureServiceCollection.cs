using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
	public static IServiceCollection ConfigureServices(this IServiceCollection services)
	{
		services.AddDbContext<Context>();

		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		services.AddScoped(typeof(IApplicationAlunoService), typeof(ApplicationAlunoService));
		services.AddScoped(typeof(IDomainAlunoService), typeof(DomainAlunoService));
		services.AddScoped(typeof(IAlunoRepository), typeof(AlunoRepository));

		return services;
	}
}
