using Project.SchoolDepartment.Application.DTOs.Contratcts;

namespace Project.SchoolDepartment.Application.DTOs;

public class PaginatedDTO<T> : IDTO
{
	public int Page { get; set; }
	public int Pages { get; set; }
	public int Total { get; set; }
	public List<T>? Data { get; set; }
}
