using Project.SchoolDepartment.Domain.Requests.Contracts;

namespace Project.SchoolDepartment.Domain.Requests;

public class CourseRequest : IRequest
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public Guid? StudentId { get; set; }
	public Guid? SchoolId { get; set; }
}
