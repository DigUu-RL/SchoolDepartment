using Microsoft.AspNetCore.Mvc;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
	[HttpPost]
	public async Task<IActionResult> SendConfirmationLink(Guid user)
	{
		return NoContent();
	}
}
