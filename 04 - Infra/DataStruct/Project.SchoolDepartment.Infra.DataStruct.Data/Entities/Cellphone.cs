using System.Text.Json.Serialization;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class Cellphone : EntityBase
{
	public string Number { get; set; } = string.Empty;

	// relationships
	public Guid? StudentId { get; set; }
	public Student? Student { get; set; }
}
