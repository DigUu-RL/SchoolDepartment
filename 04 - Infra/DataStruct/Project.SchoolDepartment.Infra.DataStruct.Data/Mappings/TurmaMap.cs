using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

public sealed class TurmaMap : IEntityTypeConfiguration<Turma>
{
	public void Configure(EntityTypeBuilder<Turma> builder)
	{
		builder.ToTable(nameof(Turma));

		builder.HasKey(x => x.Guid);

		builder
			.Property(x => x.Guid)
			.ValueGeneratedOnAdd();

		builder
			.Property(x => x.QuantidadeAlunos)
			.IsRequired();

		builder
			.Property(x => x.Periodo)
			.HasColumnType("VARCHAR")
			.HasMaxLength(5)
			.IsRequired();

		builder
			.Property(x => x.DataInicio)
			.IsRequired();

		builder
			.Property(x => x.DataFim)
			.IsRequired();
	}

	public static void PreLoadedData(ModelBuilder modelBuilder)
	{
		var turmas = new List<Turma> 
		{
			new Turma 
			{
				Guid = Guid.Parse("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"),
				QuantidadeAlunos = 1,
				Periodo = Periodo.Manha,
				DataInicio = new DateTime(),
				DataFim = new DateTime(),
				CursoGuid = Guid.Parse("a69dda80-aed1-452a-afa7-5c09d4885ba1")
			} 
		};

		modelBuilder.Entity<Turma>().HasData(turmas);
	}
}
