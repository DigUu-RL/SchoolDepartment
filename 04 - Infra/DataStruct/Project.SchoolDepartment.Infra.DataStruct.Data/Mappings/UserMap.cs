using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable(nameof(User));

		builder.HasKey(x => x.Guid);

		builder
			.HasIndex(x => x.Token)
			.IsUnique();

		builder
			.Property(x => x.Guid)
			.ValueGeneratedOnAdd();

		builder
			.Property(x => x.Login)
			.HasColumnType("VARCHAR")
			.HasMaxLength(150)
			.IsRequired();

		builder
			.Property(x => x.Email)
			.HasColumnType("VARCHAR")
			.HasMaxLength(200)
			.IsRequired();

		builder
			.Property(x => x.PasswordHash)
			.HasColumnType("VARCHAR")
			.HasMaxLength(255)
			.IsRequired();

		builder
			.Property(x => x.IsStudent)
			.HasDefaultValue(true)
			.IsRequired();

		builder
			.Property(x => x.Token)
			.HasColumnType("VARCHAR")
			.HasMaxLength(255)
			.IsRequired();

		builder
			.Property(x => x.IsConfirmed)
			.HasDefaultValue(false)
			.IsRequired();
	}

	public static void PreLoadedData(ModelBuilder builder)
	{
		var users = new List<User>
		{
			new User
			{
				Guid = Guid.Parse("9284F301-155A-4642-A526-BD7B941DDD9A"),
				Login = "diguu_rl",
				Email = "rodrigogeribola@hotmail.com",
				PasswordHash = "8sfM3ZZo4QvV7xKGxIyvg441+YFCuWMicZOM0Aqlj05p5a/buyT+keDIRYv6sd5/wkm1pCaePa+Ry6eAksgJ2w==",
				Token = "MyFirstToken1234567890++"
			}
		};

		builder.Entity<User>().HasData(users);
	}
}
