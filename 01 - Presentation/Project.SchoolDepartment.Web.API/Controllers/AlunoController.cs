using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
[Route("api/aluno")]
public class AlunoController : ControllerBase
{
	[HttpGet]
	public IActionResult Teste()
	{
		string? s = string.Empty;

		try
		{
			BackgroundJob.Enqueue(() => WriteNumbersAsync());
		}
		catch (Exception ex)
		{
			s = ex.InnerException?.Message;
		}

		return Ok(s);
	}

	[NonAction]
	public void WriteNumbersAsync()
	{
		for (int i = 0; i < 1000; i++)
		{
			System.IO.File.WriteAllText($@"C:\Users\rodri\Downloads\text{1 + i}.txt", "file number: " + (1 + i));
		}
	}
}
