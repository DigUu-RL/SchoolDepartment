using Microsoft.AspNetCore.Mvc;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
[Route("api/aluno")]
public class AlunoController : ControllerBase
{
	private readonly IApplicationAlunoService _alunoService;

	public AlunoController(IApplicationAlunoService alunoService)
	{
		_alunoService = alunoService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll(int page = 1, int quantity = 10)
	{
		return Ok(await _alunoService.GetAllAsync(page, quantity));
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		return Ok(await _alunoService.GetByIdAsync(id));
	}

	[HttpPost("create")]
	public async Task<IActionResult> Create([FromBody] AlunoRequest request)
	{
		await _alunoService.CreateAsync(request);
		return Ok();
	}

	[HttpPut("update")]
	public async Task<IActionResult> Update([FromBody] AlunoRequest request)
	{
		await _alunoService.UpdateAsync(request);
		return NoContent();
	}

	[HttpDelete("delete/{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _alunoService.DeleteAsync(id);
		return NoContent();
	}
}
