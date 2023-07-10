using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Domain.Interfaces;

public interface IDomainStudentService
{
	Task<PaginatedModel<StudentModel>> GetAllAsync(Search<StudentRequest> search);
	Task<StudentModel> GetByIdAsync(Guid guid);
	Task CreateAsync(StudentRequest request);
	Task UpdateAsync(StudentRequest request);
	Task DeleteAsync(Guid id);
}
