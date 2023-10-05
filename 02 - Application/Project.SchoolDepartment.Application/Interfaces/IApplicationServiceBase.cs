using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Domain.Helpers;

namespace Project.SchoolDepartment.Application.Interfaces;

public interface IApplicationServiceBase<TDTO, TRequest> where TRequest : class
{
	Task<PaginatedDTO<TDTO>> GetAsync(Search<TRequest> search);
	Task<TDTO> GetByIdAsync(Guid id);
	Task CreateAsync(TRequest request);
	Task UpdateAsync(TRequest request);
	Task DeleteAsync(Guid id);
	void Validate(TRequest request);
}
