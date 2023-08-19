using Microsoft.AspNetCore.Mvc;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
	private readonly IApplicationStudentService _studentService;

	public StudentController(IApplicationStudentService studentService)
	{
		_studentService = studentService;
	}

	[HttpGet]
	public async Task<IActionResult> Get([FromQuery] Search<StudentRequest> search)
	{
		return Ok(await _studentService.GetAsync(search));
	}

	[HttpGet("all")]
	public async Task<IActionResult> GetAll()
	{
		return Ok();
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		return Ok(await _studentService.GetByIdAsync(id));
	}

	[HttpPost("create")]
	public async Task<IActionResult> Create([FromBody] StudentRequest request)
	{
		await _studentService.CreateAsync(request);
		return Ok();
	}

	[HttpPut("update")]
	public async Task<IActionResult> Update([FromBody] StudentRequest request)
	{
		await _studentService.UpdateAsync(request);
		return NoContent();
	}

	[HttpDelete("delete/{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _studentService.DeleteAsync(id);
		return NoContent();
	}
}
