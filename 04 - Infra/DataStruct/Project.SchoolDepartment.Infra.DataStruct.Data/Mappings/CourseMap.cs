using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

public sealed class CourseMap : IEntityTypeConfiguration<Course>
{
	public void Configure(EntityTypeBuilder<Course> builder)
	{
		builder.ToTable(nameof(Course));

		builder.HasKey(x => x.Guid);

		builder
			.Property(x => x.Guid)
			.ValueGeneratedOnAdd();

		builder
			.Property(x => x.Name)
			.HasColumnType("VARCHAR")
			.HasMaxLength(180)
			.IsRequired();
	}

	public static void PreLoadedData(ModelBuilder modelBuilder)
	{
		var courses = new List<Course>
		{
			new Course
			{
				Guid = Guid.Parse("a69dda80-aed1-452a-afa7-5c09d4885ba1"),
				Name = "Ciência da Computação"
			}
		};

		modelBuilder.Entity<Course>().HasData(courses);
	}
}
