namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class Course : EntityBase
{
	public string Name { get; set; } = string.Empty;

	// relationships
	public ICollection<Student>? Students { get; set; }
	public ICollection<School>? Schools { get; set; }
}
