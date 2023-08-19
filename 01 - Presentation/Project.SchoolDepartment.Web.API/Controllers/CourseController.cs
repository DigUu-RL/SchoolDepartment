using Microsoft.AspNetCore.Mvc;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Web.API.Controllers;

[ApiController]
[Route("api/course")]
public class CourseController : Controller
{
	private readonly IApplicationCourseService _courseService;

	public CourseController(IApplicationCourseService courseService)
	{
		_courseService = courseService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAsync([FromQuery] Search<CourseRequest> search)
	{
		PaginatedDTO<CourseDTO> data = await _courseService.GetAsync(search);
		return Ok(data);
	}
}
