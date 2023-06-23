using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class Student : EntityBase
{
	public string Name { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string CPF { get; set; } = string.Empty;
	public string RA { get; set; } = string.Empty;
	public Gender Gender { get; set; }
	public string Street { get; set; } = string.Empty;
	public string District { get; set; } = string.Empty;
	public int Number { get; set; }
	public string City { get; set; } = string.Empty;
	public string State { get; set; } = string.Empty;

	// relationships
	public Guid? CourseId { get; set; }
	public Course? Course { get; set; }
	public Guid? SchoolId { get; set; }
	public School? School { get; set; }
	public ICollection<Cellphone>? Cellphones { get; set; }
	public Guid? UserId { get; set; }
	public User? User { get; set; }

	public override string ToString()
	{
		return $"{Id}.{Name} {LastName}";
	}
}
