using Microsoft.AspNetCore.Mvc;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
[Route("api/aluno")]
public class StudentController : ControllerBase
{
	private readonly IApplicationAlunoService _studentService;

	public StudentController(IApplicationAlunoService alunoService)
	{
		_studentService = alunoService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll(int page = 1, int quantity = 10)
	{
		return Ok(await _studentService.GetAllAsync(page, quantity));
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		return Ok(await _studentService.GetByIdAsync(id));
	}

	[HttpPost("create")]
	public async Task<IActionResult> Create([FromBody] AlunoRequest request)
	{
		await _studentService.CreateAsync(request);
		return Ok();
	}

	[HttpPut("update")]
	public async Task<IActionResult> Update([FromBody] AlunoRequest request)
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
