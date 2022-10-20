using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;

public class Context : DbContext
{
	// private string connectionString = "Server = localhost; Database = school_department_db; User Id = root; Password = Veneno13$;";

	private readonly IConfiguration _configuration;

	public Context()
	{

	}

	public Context(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public DbSet<Aluno> Aluno { get; set; }
	public DbSet<Curso> Curso { get; set; }
	public DbSet<Turma> Turma { get; set; }
	public DbSet<Telefone> Telefone { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SchoolDepartment"));
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
