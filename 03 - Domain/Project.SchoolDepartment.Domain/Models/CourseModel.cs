namespace Project.SchoolDepartment.Domain.Models;

public class CourseModel
{
	public Guid Guid { get; set; }
	public string? Name { get; set; }
	public ICollection<StudentModel>? Students { get; set; }
	public ICollection<SchoolModel>? Schools { get; set; }
}
