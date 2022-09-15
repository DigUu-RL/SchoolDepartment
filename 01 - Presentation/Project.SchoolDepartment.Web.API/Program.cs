using Hangfire;
using Project.SchoolDepartment.Infra.CrossCutting.CCT;
using Project.SchoolDepartment.Infra.Middleware;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureServices(builder.Configuration);

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware(typeof(ErrorMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
