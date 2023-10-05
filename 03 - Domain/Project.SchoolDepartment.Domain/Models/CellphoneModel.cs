using Project.SchoolDepartment.Domain.Attributes;

namespace Project.SchoolDepartment.Domain.Models;

[Model]
public class CellphoneModel
{
	public Guid? Id { get; set; }
	public string? Number { get; set; }

	// relationships
	public Guid? StudentId { get; set; }
	public StudentModel? Student { get; set; }
}
