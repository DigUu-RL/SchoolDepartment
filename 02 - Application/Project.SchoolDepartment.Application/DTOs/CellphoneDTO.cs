namespace Project.SchoolDepartment.Application.DTOs;

public class CellphoneDTO
{
	public Guid Guid { get; set; }
	public string? Number { get; set; }
	public StudentDTO? Student { get; set; }
}
