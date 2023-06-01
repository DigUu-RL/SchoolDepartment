using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Domain.Interfaces;

public interface IDomainStudentService : IDomainServiceBase
{
	Task<PaginatedModel<StudentModel>> GetAllAsync(int page, int quantity);
	Task<StudentModel> GetByGuidAsync(Guid guid);
	Task CreateAsync(StudentRequest request);
	Task UpdateAsync(StudentRequest request);
	Task DeleteAsync(Guid id);
}
