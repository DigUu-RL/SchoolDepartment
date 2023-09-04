using Project.SchoolDepartment.Domain.Models.Contracts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Domain.Models;

public class StudentModel : IModel
{
	public Guid? Id { get; set; }
	public string? Name { get; set; } = string.Empty;
	public string? LastName { get; set; } = string.Empty;
	public string? CPF { get; set; } = string.Empty;
	public string? RA { get; set; } = string.Empty;
	public Gender? Gender { get; set; }
	public string? Street { get; set; } = string.Empty;
	public string? District { get; set; } = string.Empty;
	public int? Number { get; set; }
	public string? City { get; set; } = string.Empty;
	public string? State { get; set; } = string.Empty;

	// relationships
	public Guid? CourseId { get; set; }
	public CourseModel? Course { get; set; }
	public Guid? SchoolId { get; set; }
	public SchoolModel? School { get; set; }
	public ICollection<CellphoneModel>? Cellphones { get; set; }

	public override string ToString()
	{
		return $"{Id}.{Name} {LastName}";
	}
}
