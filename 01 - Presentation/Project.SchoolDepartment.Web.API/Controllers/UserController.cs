using Microsoft.AspNetCore.Mvc;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
	private readonly IApplicationUserService _userService;

	public UserController(IApplicationUserService userService)
	{
		_userService = userService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll(int page = 1, int quantity = 10)
	{
		PaginatedDTO<UserDTO> users = await _userService.GetAllAsync(page, quantity);
		return Ok(users);
	}

	[HttpGet("{guid}")]
	public async Task<IActionResult> GetByGuid(Guid guid)
	{
		UserDTO user = await _userService.GetByGuidAsync(guid);
		return Ok(user);
	}

	[HttpPost("create")]
	public async Task<IActionResult> Create(UserRequest request)
	{
		await _userService.CreateAsync(request);
		return Ok();
	}

	[HttpPut("update")]
	public async Task<IActionResult> Update(UserRequest request)
	{
		await _userService.UpdateAsync(request);
		return NoContent();
	}

	[HttpDelete("delete/{guid}")]
	public async Task<IActionResult> Delete(Guid guid)
	{
		await _userService.DeleteAsync(guid);
		return NoContent();
	}

	[HttpPost("send-confirmation-link/{guid}")]
	public async Task<IActionResult> SendConfirmationLink(Guid guid)
	{
		await _userService.SendConfirmationLink(guid);
		return NoContent();
	}

	[HttpPut("confirm-link/{guid}/{token}")]
	public async Task<IActionResult> ConfirmLink(Guid guid, string token)
	{
		await _userService.ConfirmLink(guid, token);
		return NoContent();
	}
}
