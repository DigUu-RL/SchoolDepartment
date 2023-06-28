namespace Project.SchoolDepartment.Application.DTOs;

public class CourseDTO
{
	public Guid Guid { get; set; }
	public string Name { get; set; } = string.Empty;
	public ICollection<StudentDTO>? Students { get; set; }
	public ICollection<SchoolDTO>? Schools { get; set; }
}
