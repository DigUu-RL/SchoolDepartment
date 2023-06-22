namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class Cellphone : EntityBase
{
	public string? Number { get; set; }

	// relationships
	public Guid StudentId { get; set; }
	public Student? Student { get; set; }
}
