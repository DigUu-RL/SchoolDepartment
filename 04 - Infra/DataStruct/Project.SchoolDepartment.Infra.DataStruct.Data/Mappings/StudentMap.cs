using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

public sealed class StudentMap : IEntityTypeConfiguration<Student>
{
	public void Configure(EntityTypeBuilder<Student> builder)
	{
		builder.ToTable(nameof(Student));

		builder.HasKey(x => x.Id);

		builder
			.HasIndex(x => x.CPF)
			.IsUnique();

		builder
			.HasIndex(x => x.RA)
			.IsUnique();

		builder
			.Property(x => x.Id)
			.ValueGeneratedOnAdd();

		builder
			.Property(x => x.Name)
			.HasColumnType("VARCHAR")
			.HasMaxLength(60)
			.IsRequired();

		builder
			.Property(x => x.LastName)
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
			.Property(x => x.Gender)
			.HasColumnType("VARCHAR")
			.HasMaxLength(50)
			.IsRequired();

		builder
			.Property(x => x.Street)
			.HasColumnType("VARCHAR")
			.HasMaxLength(160)
			.IsRequired();

		builder
			.Property(x => x.District)
			.HasColumnType("VARCHAR")
			.HasMaxLength(80)
			.IsRequired();

		builder
			.Property(x => x.Number)
			.IsRequired();

		builder
			.Property(x => x.City)
			.HasColumnType("VARCHAR")
			.HasMaxLength(60)
			.IsRequired();

		builder
			.Property(x => x.State)
			.HasColumnType("CHAR")
			.HasMaxLength(2)
			.IsRequired();

		builder
			.Property(x => x.SchoolId)
			.HasDefaultValue(Guid.Empty);

		builder
			.Property(x => x.CourseId)
			.HasDefaultValue(Guid.Empty);

		builder
			.Property(x => x.UserId)
			.HasDefaultValue(Guid.Empty);
	}

	public static void PreLoadedData(ModelBuilder modelBuilder)
	{
		var students = new List<Student>
		{
			new Student
			{
				Id = Guid.Parse("c70c3bce-c77a-428a-b8c1-28174b6e0ba6"),
				Name = "Eduardo",
				LastName = "Oliveira da Silva",
				CPF = "11111111111",
				RA = "SFHJHSJH46JY54JY6JS54GARGHSTAEFGSJ4T65TRYH48TSRJTJ5THS5TRHGHAEJKDLF846531AHKFSFJ",
				Gender = Gender.Male,
				Street = "Rua Aleatória",
				District = "Bairro Qualquer",
				Number = 278,
				City = "Cidade Qualquer",
				State = "SP",
				CourseId = Guid.Parse("a69dda80-aed1-452a-afa7-5c09d4885ba1"),
				SchoolId = Guid.Parse("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"),
				UserId = Guid.Parse("9284F301-155A-4642-A526-BD7B941DDD9A")
			}
		};

		modelBuilder.Entity<Student>().HasData(students);
	}
}
