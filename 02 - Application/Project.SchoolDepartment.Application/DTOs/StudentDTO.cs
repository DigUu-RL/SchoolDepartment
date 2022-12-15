using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Application.DTOs;

public class StudentDTO
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
	public Guid CourseGuid { get; set; }
	public CourseDTO? Course { get; set; }
	public Guid SchoolGuid { get; set; }
	public SchoolDTO? School { get; set; }
	public ICollection<CellphoneDTO>? Cellphones { get; set; }
}
