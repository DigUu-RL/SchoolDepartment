using Project.SchoolDepartment.Domain.Requests.Contracts;

namespace Project.SchoolDepartment.Domain.Helpers;

public class Search<TRequest> where TRequest : class, IRequest
{
	public int Page { get; set; }
	public int Quantity { get; set; }
	public TRequest? Filter { get; set; } = typeof(TRequest).GetConstructor(Type.EmptyTypes)?.Invoke(null) as TRequest;
}
