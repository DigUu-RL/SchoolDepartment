using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class Student : EntityBase
{
	public string? Name { get; set; }
	public string? Lastname { get; set; }
	public string? CPF { get; set; }
	public string? RA { get; set; }
	public Gender Gender { get; set; }
	public string? Street { get; set; }
	public string? District { get; set; }
	public int Number { get; set; }
	public string? City { get; set; }
	public string? State { get; set; }

	// relationships
	public Guid CourseGuid { get; set; }
	public Course? Course { get; set; }
	public Guid SchoolGuid { get; set; }
	public School? School { get; set; }
	public ICollection<Cellphone>? Cellphones { get; set; }
	public Guid UserGuid { get; set; }
	public User? User { get; set; }
}
