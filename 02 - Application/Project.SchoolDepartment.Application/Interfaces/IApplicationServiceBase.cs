using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.DTOs.Contratcts;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Requests.Contracts;

namespace Project.SchoolDepartment.Application.Interfaces;

public interface IApplicationServiceBase<TDTO, TRequest>
	where TDTO : IDTO
	where TRequest : class, IRequest

{
	Task<PaginatedDTO<TDTO>> GetAsync(Search<TRequest> search);
	Task<TDTO> GetByIdAsync(Guid id);
	Task CreateAsync(TRequest request);
	Task UpdateAsync(TRequest request);
	Task DeleteAsync(Guid id);
}
