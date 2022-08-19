using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

public class TelefoneMap : IEntityTypeConfiguration<Telefone>
{
	public void Configure(EntityTypeBuilder<Telefone> builder)
	{
		builder.HasKey(x => x.Guid);
		
		builder
			.Property(x => x.Numero)
			.HasColumnType("VARCHAR")
			.HasMaxLength(11)
			.IsRequired();
	}

	public static void PreLoadedData(ModelBuilder modelBuilder)
	{
		var telefones = new List<Telefone>
		{
			new Telefone
			{
				Guid = Guid.NewGuid(),
				Numero = "9".PadRight(11, '9')
			},
			new Telefone
			{
				Guid = Guid.NewGuid(),
				Numero = "8".PadRight(11, '8')
			}
		};

		telefones.ForEach(x => modelBuilder.Entity<Telefone>().HasData(x));
	}
}
