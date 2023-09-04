using Project.SchoolDepartment.Application.DTOs.Contratcts;

namespace Project.SchoolDepartment.Application.DTOs;

public class CellphoneDTO : IDTO
{
	public Guid? Id { get; set; }
	public string? Number { get; set; }

	// relationships
	public Guid? StudentId { get; set; }
	public StudentDTO? Student { get; set; }
}