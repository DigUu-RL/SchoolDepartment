using Project.SchoolDepartment.Domain.Models.Contracts;

namespace Project.SchoolDepartment.Domain.Models;

public class CourseModel : IModel
{
	public Guid? Id { get; set; }
	public string? Name { get; set; }

	// relationships
	public ICollection<StudentModel>? Students { get; set; }
	public ICollection<SchoolModel>? Schools { get; set; }
}
