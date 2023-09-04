using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;

public class AppDbContext : DbContext
{
	private readonly IConfiguration _configuration;

	public AppDbContext()
	{

	}

	public AppDbContext(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		string? connectionString = _configuration.GetConnectionString(nameof(SchoolDepartment));
		optionsBuilder.UseSqlServer(connectionString);

		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new StudentMap());
		modelBuilder.ApplyConfiguration(new CourseMap());
		modelBuilder.ApplyConfiguration(new SchoolMap());
		modelBuilder.ApplyConfiguration(new CellphoneMap());

		StudentMap.PreLoadedData(modelBuilder);
		CourseMap.PreLoadedData(modelBuilder);
		SchoolMap.PreLoadedData(modelBuilder);
		CellphoneMap.PreLoadedData(modelBuilder);

		base.OnModelCreating(modelBuilder);
	}
}
