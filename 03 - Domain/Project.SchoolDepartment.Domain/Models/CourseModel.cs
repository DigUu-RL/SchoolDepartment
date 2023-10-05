using Project.SchoolDepartment.Domain.Attributes;

namespace Project.SchoolDepartment.Domain.Models;

[Model]
public class CourseModel
{
	public Guid? Id { get; set; }
	public string? Name { get; set; }

	// relationships
	public ICollection<StudentModel>? Students { get; set; }
	public ICollection<SchoolModel>? Schools { get; set; }
}
