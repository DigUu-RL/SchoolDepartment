using Microsoft.AspNetCore.Mvc;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
[Route("api/course")]
public class CourseController : BaseController<CourseRequest>
{
	private readonly IApplicationCourseService _courseService;

	public CourseController(IApplicationCourseService courseService)
	{
		_courseService = courseService;
	}

	[HttpPost]
	public override Task<IActionResult> Create([FromBody] CourseRequest request)
	{
		throw new NotImplementedException();
	}

	[HttpDelete("delete/{id}")]
	public override Task<IActionResult> Delete(Guid id)
	{
		throw new NotImplementedException();
	}

	[HttpGet]
	public override async Task<IActionResult> GetAll([FromQuery] Search<CourseRequest> search)
	{
		PaginatedDTO<CourseDTO> data = await _courseService.GetAsync(search);
		return Ok(data);
	}


	[HttpGet("{id}")]
	public override Task<IActionResult> GetById(Guid id)
	{
		throw new NotImplementedException();
	}

	[HttpPut]
	public override Task<IActionResult> Update([FromBody] CourseRequest request)
	{
		throw new NotImplementedException();
	}
}
