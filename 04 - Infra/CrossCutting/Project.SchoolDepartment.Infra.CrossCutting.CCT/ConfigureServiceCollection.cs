using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Application.Services;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Services;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;
using Project.SchoolDepartment.Integration.Interfaces;
using Project.SchoolDepartment.Integration.Services;
using System.Net;
using System.Threading.RateLimiting;

namespace Project.SchoolDepartment.Infra.CrossCutting.CCT;

public static class ConfigureServiceCollection
{
	public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
	{
		Console.WriteLine("Starting register project dependecies...");

		services.AddDbContext<AppDbContext>();

		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		services.AddScoped(typeof(IIntegrationApiService), typeof(IntegrationApiService));

		services.AddScoped(typeof(IApplicationStudentService), typeof(ApplicationStudentService));
		services.AddScoped(typeof(IDomainStudentService), typeof(DomainStudentService));
		services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));

		services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

		// configuring the requests limiter
		services.AddRateLimiter(x =>
		{
			x.RejectionStatusCode = (int) HttpStatusCode.TooManyRequests;

			x.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context => RateLimitPartition.GetFixedWindowLimiter(
				context.User?.Identity?.Name ?? context.Request.Headers.Host,
				factory => new FixedWindowRateLimiterOptions
				{
					AutoReplenishment = true,
					PermitLimit = 10,
					QueueLimit = 0,
					Window = TimeSpan.FromMinutes(5)
				})!
			);
		});

		Console.WriteLine("Project dependencies are configured!");

		services.ConfigureHangfire(configuration);

		return services;
	}

	private static IServiceCollection ConfigureHangfire(this IServiceCollection services, IConfiguration configuration)
	{
		Console.WriteLine("Starting configure Hangfire Recurring Jobs...");
		services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString(nameof(Hangfire))));

		// configure recurring jobs ...

		Console.WriteLine("Recurring Jobs are configured!");

		return services;
	}
}
