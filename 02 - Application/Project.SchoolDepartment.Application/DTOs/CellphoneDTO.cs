namespace Project.SchoolDepartment.Application.DTOs;

public class CellphoneDTO
{
    public Guid? Id { get; set; }
    public string? Number { get; set; }

	// relationships
	public Guid? StudentId { get; set; }
	public StudentDTO? Student { get; set; }
}