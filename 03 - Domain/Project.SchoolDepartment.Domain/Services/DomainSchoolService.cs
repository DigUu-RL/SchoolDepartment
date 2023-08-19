using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Domain.Services;

public class DomainSchoolService : IDomainSchoolService
{
	public Task CreateAsync(SchoolRequest request)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<PaginatedModel<SchoolModel>> GetAllAsync(Search<SchoolRequest> search)
	{
		throw new NotImplementedException();
	}

	public Task<SchoolModel> GetByIdAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(SchoolRequest request)
	{
		throw new NotImplementedException();
	}
}
