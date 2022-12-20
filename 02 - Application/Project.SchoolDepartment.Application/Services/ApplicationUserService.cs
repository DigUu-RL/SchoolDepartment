using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Application.Services;

public class ApplicationUserService : IApplicationUserService
{
	private readonly IDomainUserService _userService;

	public ApplicationUserService(IDomainUserService userService)
	{
		_userService = userService;
	}

	public Task ConfirmLink(Guid guid, string token)
	{
		throw new NotImplementedException();
	}

	public Task CreateAsync(UserRequest request)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(Guid guid)
	{
		throw new NotImplementedException();
	}

	public Task<PaginatedDTO<UserDTO>> GetAllAsync(int page, int quantity)
	{
		throw new NotImplementedException();
	}

	public Task<UserDTO> GetByGuidAsync(Guid guid)
	{
		throw new NotImplementedException();
	}

	public Task SendConfirmationLink(Guid guid)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(UserRequest request)
	{
		throw new NotImplementedException();
	}
}
