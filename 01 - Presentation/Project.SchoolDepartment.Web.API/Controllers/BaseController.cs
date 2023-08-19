using Microsoft.AspNetCore.Mvc;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Requests.Contracts;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
public abstract class BaseController<TRequest> : ControllerBase where TRequest : class, IRequest
{
	public abstract Task<IActionResult> GetAll([FromQuery] Search<TRequest> search);
	public abstract Task<IActionResult> GetById(Guid id);
	public abstract Task<IActionResult> Create([FromBody] TRequest request);
	public abstract Task<IActionResult> Update([FromBody] TRequest request);
	public abstract Task<IActionResult> Delete(Guid id);
}
