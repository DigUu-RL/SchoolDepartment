using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Domain.Models;

public class StudentModel
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
	public CourseModel? Course { get; set; }
	public Guid SchoolGuid { get; set; }
	public SchoolModel? School { get; set; }
	public ICollection<CellphoneModel>? Cellphones { get; set; }
}
