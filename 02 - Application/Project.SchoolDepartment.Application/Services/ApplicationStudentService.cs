using AutoMapper;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Application.Services;

public class ApplicationStudentService : IApplicationStudentService
{
	private readonly IDomainStudentService _studentService;
	private readonly IMapper _mapper;

	public ApplicationStudentService(IDomainStudentService studentService, IMapper mapper)
	{
		_studentService = studentService;
		_mapper = mapper;
	}

	public async Task<PaginatedDTO<StudentDTO>> GetAllAsync(int page, int quantity)
	{
		PaginatedDTO<StudentDTO> data = _mapper.Map<PaginatedDTO<StudentDTO>>(await _studentService.GetAllAsync(page, quantity));
		return data;
	}

	public async Task<StudentDTO> GetByIdAsync(Guid id)
	{
		StudentDTO data = _mapper.Map<StudentDTO>(await _studentService.GetByIdAsync(id));
		return data;
	}

	public async Task CreateAsync(StudentRequest request)
	{
		await _studentService.CreateAsync(request);
	}

	public async Task UpdateAsync(StudentRequest request)
	{
		await _studentService.UpdateAsync(request);
	}

	public async Task DeleteAsync(Guid id)
	{
		await _studentService.DeleteAsync(id);
	}
}
