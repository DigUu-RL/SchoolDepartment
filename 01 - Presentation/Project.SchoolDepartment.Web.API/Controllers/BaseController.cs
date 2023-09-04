using Microsoft.AspNetCore.Mvc;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Requests.Contracts;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
public abstract class BaseController<TRequest> : ControllerBase where TRequest : class, IRequest
{
	[HttpGet]
	public abstract Task<IActionResult> GetAll([FromQuery] Search<TRequest> search);

	[HttpGet("{id}")]
	public abstract Task<IActionResult> GetById(Guid id);

	[HttpPost]
	public abstract Task<IActionResult> Create([FromBody] TRequest request);

	[HttpPut]
	public abstract Task<IActionResult> Update([FromBody] TRequest request);

	[HttpDelete("delete/{id}")]
	public abstract Task<IActionResult> Delete(Guid id);
}
