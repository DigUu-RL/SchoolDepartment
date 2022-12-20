using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Domain.Interfaces;

public interface IDomainUserService
{
	Task<PaginatedModel<UserModel>> GetAllAsync(int page, int quantity);
	Task<UserModel> GetByGuidAsync(Guid guid);
	Task CreateAsync(UserRequest request);
	Task UpdateAsync(UserRequest request);
	Task DeleteAsync(Guid guid);
	Task SendConfirmationLink(Guid guid);
	Task ConfirmLink(Guid guid, string token);
}
