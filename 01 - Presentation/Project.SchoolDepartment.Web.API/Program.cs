using Hangfire;
using Hangfire.MySql;
using Project.SchoolDepartment.Infra.CrossCutting.CCT;
using Project.SchoolDepartment.Infra.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ApplyDependencyInjection();
builder.Services.ApplyHangFire(builder.Configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

	app.UseHangfireDashboard();
}

app.UseMiddleware(typeof(ErrorMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
