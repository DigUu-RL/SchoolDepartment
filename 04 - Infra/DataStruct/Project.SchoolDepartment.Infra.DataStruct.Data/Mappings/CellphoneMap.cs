using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

public sealed class CellphoneMap : IEntityTypeConfiguration<Cellphone>
{
	public void Configure(EntityTypeBuilder<Cellphone> builder)
	{
		builder.ToTable(nameof(Cellphone));

		builder.HasKey(x => x.Id);

		builder
			.Property(x => x.Id)
			.ValueGeneratedOnAdd();

		builder
			.Property(x => x.Number)
			.HasColumnType("VARCHAR")
			.HasMaxLength(11)
			.IsRequired();

		builder
			.Property(x => x.StudentId)
			.HasDefaultValue(null);
	}

	public static void PreLoadedData(ModelBuilder modelBuilder)
	{
		var cellphones = new List<Cellphone>
		{
			new Cellphone
			{
				Id = Guid.NewGuid(),
				Number = "9".PadRight(11, '9'),
				StudentId = Guid.Parse("c70c3bce-c77a-428a-b8c1-28174b6e0ba6")
			},
			new Cellphone
			{
				Id = Guid.NewGuid(),
				Number = "8".PadRight(11, '8'),
				StudentId = Guid.Parse("c70c3bce-c77a-428a-b8c1-28174b6e0ba6")
			}
		};

		modelBuilder.Entity<Cellphone>().HasData(cellphones);
	}
}
