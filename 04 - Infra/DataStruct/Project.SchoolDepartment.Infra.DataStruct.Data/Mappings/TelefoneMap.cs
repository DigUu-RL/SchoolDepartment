using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

public sealed class TelefoneMap : IEntityTypeConfiguration<Telefone>
{
	public void Configure(EntityTypeBuilder<Telefone> builder)
	{
		builder.ToTable(nameof(Telefone));

		builder.HasKey(x => x.Guid);

		builder
			.Property(x => x.Guid)
			.ValueGeneratedOnAdd();
		
		builder
			.Property(x => x.Numero)
			.HasColumnType("VARCHAR")
			.HasMaxLength(11)
			.IsRequired();

		builder
			.Property(x => x.AlunoGuid)
			.HasDefaultValue(Guid.Empty);
	}

	public static void PreLoadedData(ModelBuilder modelBuilder)
	{
		var telefones = new List<Telefone>
		{
			new Telefone
			{
				Guid = Guid.NewGuid(),
				Numero = "9".PadRight(11, '9'),
				AlunoGuid = Guid.Parse("c70c3bce-c77a-428a-b8c1-28174b6e0ba6")
			},
			new Telefone
			{
				Guid = Guid.NewGuid(),
				Numero = "8".PadRight(11, '8'), 
				AlunoGuid = Guid.Parse("c70c3bce-c77a-428a-b8c1-28174b6e0ba6")
			}
		};

		modelBuilder.Entity<Telefone>().HasData(telefones);
	}
}
