using Project.SchoolDepartment.Domain.Attributes;

namespace Project.SchoolDepartment.Domain.Requests;

[Request]
public class CourseRequest
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public Guid? StudentId { get; set; }
	public Guid? SchoolId { get; set; }
}
