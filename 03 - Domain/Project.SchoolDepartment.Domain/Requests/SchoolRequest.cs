using Project.SchoolDepartment.Domain.Attributes;

namespace Project.SchoolDepartment.Domain.Requests;

[Request]
public class SchoolRequest
{
	public Guid? Id { get; set; }
}
