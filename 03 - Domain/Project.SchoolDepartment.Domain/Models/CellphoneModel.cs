using Project.SchoolDepartment.Domain.Models.Contracts;

namespace Project.SchoolDepartment.Domain.Models;

public class CellphoneModel : IModel
{
	public Guid? Id { get; set; }
	public string? Number { get; set; }

	// relationships
	public Guid? StudentId { get; set; }
	public StudentModel? Student { get; set; }
}
