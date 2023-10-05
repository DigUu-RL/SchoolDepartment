using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Models;

namespace Project.SchoolDepartment.Domain.Interfaces;

public interface IDomainServiceBase<TModel, TRequest> where TRequest : class
{
	Task<PaginatedModel<TModel>> GetAsync(Search<TRequest> search);
	Task<TModel> GetByIdAsync(Guid id);
	Task CreateAsync(TRequest request);
	Task UpdateAsync(TRequest request);
	Task DeleteAsync(Guid id);
}
