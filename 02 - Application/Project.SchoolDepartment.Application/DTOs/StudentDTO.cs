using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Application.DTOs;

public class StudentDTO
{
	public string Name { get; set; } = string.Empty;
	public string Lastname { get; set; } = string.Empty;
	public string CPF { get; set; } = string.Empty;
	public string RA { get; set; } = string.Empty;
	public Gender Gender { get; set; }
	public string Street { get; set; } = string.Empty;
	public string District { get; set; } = string.Empty;
	public int Number { get; set; }
	public string City { get; set; } = string.Empty;
	public string State { get; set; } = string.Empty;
	public Guid? CourseGuid { get; set; }
	public CourseDTO? Course { get; set; }
	public Guid? SchoolGuid { get; set; }
	public SchoolDTO? School { get; set; }
	public ICollection<CellphoneDTO>? Cellphones { get; set; }
}
