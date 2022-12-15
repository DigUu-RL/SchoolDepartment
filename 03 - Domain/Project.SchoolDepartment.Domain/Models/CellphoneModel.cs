namespace Project.SchoolDepartment.Domain.Models;

public class CellphoneModel
{
	public Guid Guid { get; set; }
	public string? Number { get; set; }
	public StudentModel? Student { get; set; }
}
