using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

public sealed class SchoolMap : IEntityTypeConfiguration<School>
{
	public void Configure(EntityTypeBuilder<School> builder)
	{
		builder.ToTable(nameof(School));

		builder.HasKey(x => x.Id);

		builder
			.Property(x => x.Id)
			.ValueGeneratedOnAdd();

		builder
			.Property(x => x.Period)
			.HasColumnType("VARCHAR")
			.HasMaxLength(50)
			.IsRequired();

		builder
			.Property(x => x.StartDate)
			.IsRequired();

		builder
			.Property(x => x.EndDate)
			.IsRequired();

		builder
			.Property(x => x.CourseId)
			.HasDefaultValue(Guid.Empty);
	}

	public static void PreLoadedData(ModelBuilder modelBuilder)
	{
		var turmas = new List<School> 
		{
			new School 
			{
				Id = Guid.Parse("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"),
				Period = Period.Morning,
				StartDate = new DateTime(),
				EndDate = new DateTime(),
				CourseId = Guid.Parse("a69dda80-aed1-452a-afa7-5c09d4885ba1")
			} 
		};

		modelBuilder.Entity<School>().HasData(turmas);
	}
}
