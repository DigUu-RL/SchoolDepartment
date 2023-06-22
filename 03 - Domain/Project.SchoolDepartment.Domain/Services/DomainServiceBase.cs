using Project.SchoolDepartment.Domain.Requests.Contracts;

namespace Project.SchoolDepartment.Domain.Services;

public abstract class DomainServiceBase<TRequest> where TRequest : IRequest
{
	public virtual void Validate(TRequest request)
	{
		throw new NotImplementedException();
	}
}
