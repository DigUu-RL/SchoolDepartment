using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Models.Contracts;
using Project.SchoolDepartment.Domain.Requests.Contracts;

namespace Project.SchoolDepartment.Domain.Interfaces;

public interface IDomainServiceBase<TModel, TRequest>
	where TModel : IModel
	where TRequest : class, IRequest
{
	Task<PaginatedModel<TModel>> GetAsync(Search<TRequest> search);
	Task<TModel> GetByIdAsync(Guid id);
	Task CreateAsync(TRequest request);
	Task UpdateAsync(TRequest request);
	Task DeleteAsync(Guid id);
}
