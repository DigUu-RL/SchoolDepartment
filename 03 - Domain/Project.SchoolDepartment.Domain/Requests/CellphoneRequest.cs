using Project.SchoolDepartment.Domain.Attributes;

namespace Project.SchoolDepartment.Domain.Requests;

[Request]
public class CellphoneRequest
{
	public string? Numero { get; set; }
}
