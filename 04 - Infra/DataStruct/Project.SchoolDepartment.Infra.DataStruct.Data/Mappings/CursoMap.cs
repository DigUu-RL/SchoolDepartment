using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

public class CursoMap : IEntityTypeConfiguration<Curso>
{
	public void Configure(EntityTypeBuilder<Curso> builder)
	{
		builder.HasKey(x => x.Guid);

		builder
			.Property(x => x.Nome)
			.HasColumnType("VARCHAR")
			.HasMaxLength(180)
			.IsRequired();
	}

	public static void PreLoadedData(ModelBuilder modelBuilder)
	{
		var cursos = new List<Curso>
		{
			new Curso
			{
				Guid = Guid.Parse("a69dda80-aed1-452a-afa7-5c09d4885ba1"),
				Nome = "Ciência da Computação"
			}
		};

		cursos.ForEach(x => modelBuilder.Entity<Curso>().HasData(x));
	}
}
