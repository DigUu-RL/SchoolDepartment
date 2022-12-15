using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Application.Interfaces;

public interface IApplicationStudentService
{
	Task<StudentDTO> GetByIdAsync(Guid id);
	Task<PaginatedDTO<StudentDTO>> GetAllAsync(int page, int quantity);
	Task CreateAsync(StudentRequest request);
	Task UpdateAsync(StudentRequest request);
	Task DeleteAsync(Guid id);
}
