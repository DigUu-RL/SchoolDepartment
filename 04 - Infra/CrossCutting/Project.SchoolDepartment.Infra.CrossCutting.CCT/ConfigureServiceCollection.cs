using AutoMapper;
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

		services.ConfigureMaps();

		return services;
	}

	private static IServiceCollection ConfigureMaps(this IServiceCollection services)
	{
		var profile = new MapProfile();

		#region TO DTO

		profile.CreateMap(typeof(AlunoModel), typeof(AlunoDTO));
		profile.CreateMap(typeof(CursoModel), typeof(CursoDTO));
		profile.CreateMap(typeof(TurmaModel), typeof(TurmaDTO));
		profile.CreateMap(typeof(TelefoneModel), typeof(TelefoneDTO));

		#region PAGINATED'S

		profile.CreateMap(typeof(PaginatedModel<AlunoModel>), typeof(PaginatedDTO<AlunoDTO>));
		profile.CreateMap(typeof(PaginatedModel<CursoModel>), typeof(PaginatedDTO<CursoDTO>));
		profile.CreateMap(typeof(PaginatedModel<TurmaModel>), typeof(PaginatedDTO<TurmaDTO>));
		profile.CreateMap(typeof(PaginatedModel<TelefoneModel>), typeof(PaginatedDTO<TelefoneDTO>));

		#endregion

		#endregion

		#region TO MODEL

		profile.CreateMap(typeof(Aluno), typeof(AlunoModel));
		profile.CreateMap(typeof(Curso), typeof(CursoModel));
		profile.CreateMap(typeof(Turma), typeof(TurmaModel));
		profile.CreateMap(typeof(Telefone), typeof(TelefoneModel));

		#endregion

		return services;
	}

	private static IServiceCollection ConfigureHangfire(this IServiceCollection services, IConfiguration configuration)
	{
		GlobalConfiguration.Configuration.UseSqlServerStorage(configuration.GetConnectionString("Hangfire"));

		// configure recurring jobs ...

		return services;
	}
}
