using AutoMapper;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Application.Services;

public class ApplicationCourseService : IApplicationCourseService
{
	private readonly IDomainCourseService _courseService;
	private readonly IMapper _mapper;

	public ApplicationCourseService(IDomainCourseService courseService, IMapper mapper)
	{
		_courseService = courseService;
		_mapper = mapper;
	}

	public async Task<PaginatedDTO<CourseDTO>> GetAllAsync(Search<CourseRequest> search)
	{
		PaginatedModel<CourseModel> data = await _courseService.GetAsync(search);
		return _mapper.Map<PaginatedDTO<CourseDTO>>(data);
	}

	public async Task<CourseDTO> GetByIdAsync(Guid id)
	{
		CourseModel course = await _courseService.GetByIdAsync(id);
		return _mapper.Map<CourseDTO>(course);
	}

	public async Task CreateAsync(CourseRequest request)
	{
		await _courseService.CreateAsync(request);
	}

	public async Task UpdateAsync(CourseRequest request)
	{
		await _courseService.UpdateAsync(request);
	}

	public async Task DeleteAsync(Guid id)
	{
		await _courseService.DeleteAsync(id);
	}
}
