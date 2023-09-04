using Project.SchoolDepartment.Application.DTOs.Contratcts;

namespace Project.SchoolDepartment.Application.DTOs;

public class CourseDTO : IDTO
{
	public Guid? Id { get; set; }
	public string? Name { get; set; }

	// relationships
	public ICollection<StudentDTO>? Students { get; set; }
	public ICollection<SchoolDTO>? Schools { get; set; }
}