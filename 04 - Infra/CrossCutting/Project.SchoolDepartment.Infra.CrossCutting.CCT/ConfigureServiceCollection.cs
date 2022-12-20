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
using System.Net;
using System.Threading.RateLimiting;

namespace Project.SchoolDepartment.Infra.CrossCutting.CCT;

public static class ConfigureServiceCollection
{
	public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>();

		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		services.AddScoped(typeof(IApplicationStudentService), typeof(ApplicationStudentService));
		services.AddScoped(typeof(IDomainStudentService), typeof(DomainStudentService));
		services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));

		// configuring the requests limiter
		services.AddRateLimiter(x =>
		{
			x.RejectionStatusCode = (int) HttpStatusCode.TooManyRequests;

			x.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
			{
				return RateLimitPartition.GetFixedWindowLimiter(
					context.User?.Identity?.Name ?? context.Request.Headers.Host,
					factory => new FixedWindowRateLimiterOptions
					{
						AutoReplenishment = true,
						PermitLimit = 10,
						QueueLimit = 0,
						Window = TimeSpan.FromMinutes(5)
					})!;
			});
		});

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
