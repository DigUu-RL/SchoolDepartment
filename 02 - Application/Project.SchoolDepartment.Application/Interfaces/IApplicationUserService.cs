using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Application.Interfaces;

public interface IApplicationUserService
{
	Task<PaginatedDTO<UserDTO>> GetAllAsync(int page, int quantity);
	Task<UserDTO> GetByGuidAsync(Guid guid);
	Task CreateAsync(UserRequest request);
	Task UpdateAsync(UserRequest request);
	Task DeleteAsync(Guid guid);
	Task SendConfirmationLink(Guid guid);
	Task ConfirmLink(Guid guid, string token);
}
