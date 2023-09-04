using Project.SchoolDepartment.Domain.Requests.Contracts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Domain.Requests;

public class StudentRequest : IRequest
{
	public Guid? Id { get; set; }
	public string? Name { get; set; }
	public string? LastName { get; set; }
	public string? CPF { get; set; }
	public string? RA { get; set; }
	public Gender? Gender { get; set; }
	public string? Street { get; set; }
	public string? District { get; set; }
	public int? Number { get; set; }
	public string? City { get; set; }
	public string? State { get; set; }
	public List<CellphoneRequest>? Cellphones { get; set; }
}
