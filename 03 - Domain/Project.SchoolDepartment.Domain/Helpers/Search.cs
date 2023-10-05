using Project.SchoolDepartment.Domain.Helpers.Extensions;
using Project.SchoolDepartment.Infra.Middleware.Attributes;

namespace Project.SchoolDepartment.Domain.Helpers;

public class Search<TRequest> where TRequest : class
{
	public int Page { get; set; }
	public int Quantity { get; set; }
	public TRequest? Filter { get; set; }

	public Search()
	{
		Type type = typeof(TRequest);

		if (!type.IsRequest())
			throw new InvalidOperationException("O tipo específicado não é uma Request");

		Filter = type.GetConstructor(Type.EmptyTypes)?.Invoke(null) as TRequest;
	}
}
