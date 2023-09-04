using Microsoft.AspNetCore.Mvc;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
[Route("api/student")]
public class StudentController : BaseController<StudentRequest>
{
	private readonly IApplicationStudentService _studentService;

	public StudentController(IApplicationStudentService studentService)
	{
		_studentService = studentService;
	}

	[HttpGet]
	public override async Task<IActionResult> GetAll(Search<StudentRequest> search)
	{
		return Ok(await _studentService.GetAsync(search));
	}

	[HttpGet("{id}")]
	public override async Task<IActionResult> GetById(Guid id)
	{
		return Ok(await _studentService.GetByIdAsync(id));
	}

	[HttpPost]
	public override async Task<IActionResult> Create([FromBody] StudentRequest request)
	{
		await _studentService.CreateAsync(request);
		return Ok();
	}

	[HttpPut]
	public override async Task<IActionResult> Update([FromBody] StudentRequest request)
	{
		await _studentService.UpdateAsync(request);
		return NoContent();
	}

	[HttpDelete("delete/{id}")]
	public override async Task<IActionResult> Delete(Guid id)
	{
		await _studentService.DeleteAsync(id);
		return NoContent();
	}
}
