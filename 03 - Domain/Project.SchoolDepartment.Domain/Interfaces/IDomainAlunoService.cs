using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Domain.Interfaces;

public interface IDomainAlunoService
{
	Task<PaginatedModel<AlunoModel>> GetAllAsync(int page, int quantity);
	Task<AlunoModel> GetByGuidAsync(Guid guid);
	Task CreateAsync(AlunoRequest request);
	Task UpdateAsync(AlunoRequest request);
	Task DeleteAsync(Guid id);
}
