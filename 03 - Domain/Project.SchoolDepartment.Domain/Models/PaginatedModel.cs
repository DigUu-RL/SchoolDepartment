using Project.SchoolDepartment.Domain.Models.Contracts;

namespace Project.SchoolDepartment.Domain.Models;

public class PaginatedModel<T> : IModel
{
	public int Page { get; set; }
	public int Pages { get; set; }
	public int Total { get; set; }
	public List<T>? Data { get; set; }
}
