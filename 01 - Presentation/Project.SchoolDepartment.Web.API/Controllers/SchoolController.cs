using Microsoft.AspNetCore.Mvc;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
[Route("api/school")]
public class SchoolController : BaseController<SchoolRequest>
{
	private readonly IApplicationSchoolService _schoolService;

	public SchoolController(IApplicationSchoolService schoolService)
	{
		_schoolService = schoolService;
	}

	public override async Task<IActionResult> GetAll([FromQuery] Search<SchoolRequest> search)
	{
		PaginatedDTO<SchoolDTO> data = await _schoolService.GetAllAsync(search);
		return Ok(data);
	}

	public override async Task<IActionResult> GetById(Guid id)
	{
		SchoolDTO data = await _schoolService.GetByIdAsync(id);
		return Ok(data);
	}

	public override async Task<IActionResult> Create([FromBody] SchoolRequest request)
	{
		await _schoolService.CreateAsync(request);
		return Ok();
	}

	public override async Task<IActionResult> Update([FromBody] SchoolRequest request)
	{
		await _schoolService.UpdateAsync(request);
		return NoContent();
	}

	public override async Task<IActionResult> Delete(Guid id)
	{
		await _schoolService.DeleteAsync(id);
		return NoContent();
	}
}
