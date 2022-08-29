using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

public class AlunoMap : IEntityTypeConfiguration<Aluno>
{
	public void Configure(EntityTypeBuilder<Aluno> builder)
	{
		builder.HasKey(x => x.Guid);

		builder
			.HasIndex(x => x.CPF)
			.IsUnique();

		builder
			.HasIndex(x => x.RA)
			.IsUnique();

		builder
			.Property(x => x.Nome)
			.HasColumnType("VARCHAR")
			.HasMaxLength(60)
			.IsRequired();

		builder
			.Property(x => x.Sobrenome)
			.HasColumnType("VARCHAR")
			.HasMaxLength(120)
			.IsRequired();

		builder
			.Property(x => x.CPF)
			.HasColumnType("CHAR")
			.HasMaxLength(11)
			.IsRequired();

		builder
			.Property(x => x.RA)
			.HasColumnType("CHAR")
			.HasMaxLength(80)
			.IsRequired();

		builder
			.Property(x => x.Genero)
			.HasColumnType("VARCHAR")
			.HasMaxLength(9)
			.IsRequired();

		builder
			.Property(x => x.Logradouro)
			.HasColumnType("VARCHAR")
			.HasMaxLength(160)
			.IsRequired();

		builder
			.Property(x => x.Bairro)
			.HasColumnType("VARCHAR")
			.HasMaxLength(80)
			.IsRequired();

		builder.Property(x => x.Numero).IsRequired();

		builder
			.Property(x => x.Cidade)
			.HasColumnType("VARCHAR")
			.HasMaxLength(60)
			.IsRequired();

		builder
			.Property(x => x.UF)
			.HasColumnType("CHAR")
			.HasMaxLength(2)
			.IsRequired();
	}

	public static void PreLoadedData(ModelBuilder modelBuilder)
	{
		var alunos = new List<Aluno>
		{
			new Aluno
			{
				Guid = Guid.Parse("c70c3bce-c77a-428a-b8c1-28174b6e0ba6"),
				Nome = "Eduardo",
				Sobrenome = "Oliveira da Silva",
				CPF = "11111111111",
				RA = "SFHJHSJH46JY54JY6JS54GARGHSTAEFGSJ4T65TRYH48TSRJTJ5THS5TRHGHAEJKDLF846531AHKFSFJ",
				Genero = Genero.Masculino,
				Logradouro = "Rua Aleatória",
				Bairro = "Bairro Qualquer",
				Numero = 278,
				Cidade = "Cidade Qualquer",
				UF = "SP",
				CursoGuid = Guid.Parse("a69dda80-aed1-452a-afa7-5c09d4885ba1"),
				TurmaGuid = Guid.Parse("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b")
			}
		};

		alunos.ForEach(x => modelBuilder.Entity<Aluno>().HasData(x));
	}
}
