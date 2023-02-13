using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class Student : EntityBase
{
	public string Name { get; set; } = string.Empty;
	public string Lastname { get; set; } = string.Empty;
	public string CPF { get; set; } = string.Empty;
	public string RA { get; set; } = string.Empty;
	public Gender Gender { get; set; }
	public string Street { get; set; } = string.Empty;
	public string District { get; set; } = string.Empty;
	public int Number { get; set; }
	public string City { get; set; } = string.Empty;
	public string State { get; set; } = string.Empty;

	// relationships
	public Guid CourseGuid { get; set; }
	public Course? Course { get; set; }
	public Guid SchoolGuid { get; set; }
	public School? School { get; set; }
	public ICollection<Cellphone>? Cellphones { get; set; }
	public Guid UserGuid { get; set; }
	public User? User { get; set; }
}
