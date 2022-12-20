using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;

public class AppDbContext : DbContext
{
	private const string connectionString = @"Data Source = localhost\SQLEXPRESS; 
		Initial Catalog = school_department_db; 
		Integrated Security = True; 
		Connect Timeout = 30; 
		Encrypt = False; 
		TrustServerCertificate = False; 
		ApplicationIntent = ReadWrite; 
		MultiSubnetFailover = False;";

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
		optionsBuilder.UseSqlServer(_configuration.GetConnectionString(nameof(SchoolDepartment)) /*connectionString*/);

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
