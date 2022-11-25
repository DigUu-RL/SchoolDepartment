using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Application.Services;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Services;
using Project.SchoolDepartment.Infra.CrossCutting.CCT.AutoMapper;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

namespace Project.SchoolDepartment.Infra.CrossCutting.CCT;

public static class ConfigureServiceCollection
{
	public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<Context>();

		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		services.AddScoped(typeof(IApplicationAlunoService), typeof(ApplicationAlunoService));
		services.AddScoped(typeof(IDomainAlunoService), typeof(DomainAlunoService));
		services.AddScoped(typeof(IAlunoRepository), typeof(AlunoRepository));

		services.ConfigureHangfire(configuration);

		return services;
	}

	private static IServiceCollection ConfigureHangfire(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString(nameof(Hangfire))));

		// configure recurring jobs ...

		return services;
	}
}
