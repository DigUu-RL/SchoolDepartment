using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;

public class Context : DbContext
{
	private const string connectionString = "Data Source = DIGITAL-FFPGQ4E\\SQLEXPRESS;" +
		"Initial Catalog = school_department_db;" +
		"Integrated Security = True;" +
		"Connect Timeout = 30;" +
		"Encrypt = False;" +
		"TrustServerCertificate = False;" +
		"ApplicationIntent = ReadWrite;" +
		"MultiSubnetFailover = False";

	private readonly IConfiguration _configuration;

	public Context()
	{

	}

	public Context(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(/*_configuration.GetConnectionString("SchoolDepartment")*/connectionString);
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new AlunoMap());
		modelBuilder.ApplyConfiguration(new CursoMap());
		modelBuilder.ApplyConfiguration(new TurmaMap());
		modelBuilder.ApplyConfiguration(new TelefoneMap());

		AlunoMap.PreLoadedData(modelBuilder);
		CursoMap.PreLoadedData(modelBuilder);
		TurmaMap.PreLoadedData(modelBuilder);
		TelefoneMap.PreLoadedData(modelBuilder);

		base.OnModelCreating(modelBuilder);
	}
}
