using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Application.Interfaces;

public interface IApplicationAlunoService
{
	Task<AlunoDTO> GetByIdAsync(Guid id);
	Task<PaginatedDTO<AlunoDTO>> GetAllAsync(int page, int quantity);
	Task CreateAsync(AlunoRequest request);
	Task UpdateAsync(AlunoRequest request);
	Task DeleteAsync(Guid id);
}
