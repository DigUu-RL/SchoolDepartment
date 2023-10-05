using AutoMapper;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Requests;
using Project.SchoolDepartment.Infra.Middleware.Exceptions;
using System.Net;
using InvalidDataException = Project.SchoolDepartment.Infra.Middleware.Exceptions.InvalidDataException;

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

	public async Task<PaginatedDTO<StudentDTO>> GetAsync(Search<StudentRequest> search)
	{
		PaginatedDTO<StudentDTO> data = _mapper.Map<PaginatedDTO<StudentDTO>>(await _studentService.GetAsync(search));
		return data;
	}

	public async Task<StudentDTO> GetByIdAsync(Guid id)
	{
		StudentDTO data = _mapper.Map<StudentDTO>(await _studentService.GetByIdAsync(id));
		return data;
	}

	public async Task CreateAsync(StudentRequest request)
	{
		Validate(request);

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

	public void Validate(StudentRequest request)
	{
		if (string.IsNullOrEmpty(request.Name))
			throw new RequiredDataException("Nome é obrigatório", HttpStatusCode.BadRequest);

		if (string.IsNullOrEmpty(request.LastName))
			throw new RequiredDataException("Sobrenome é obrigatório", HttpStatusCode.BadRequest);

		if (string.IsNullOrEmpty(request.CPF))
			throw new RequiredDataException("CPF é obrigatório", HttpStatusCode.BadRequest);

		if (string.IsNullOrEmpty(request.Street))
			throw new RequiredDataException("Logradouro/Rua é obrigatório", HttpStatusCode.BadRequest);

		if (string.IsNullOrEmpty(request.District))
			throw new RequiredDataException("Bairro é obrigatório", HttpStatusCode.BadRequest);

		if (!(request.Number > 0))
			throw new InvalidDataException("Número inválido", HttpStatusCode.UnprocessableEntity);

		if (string.IsNullOrEmpty(request.City))
			throw new RequiredDataException("Cidade é obrigatória", HttpStatusCode.BadRequest);

		if (string.IsNullOrEmpty(request.State))
			throw new RequiredDataException("Estado é obrigatório", HttpStatusCode.BadRequest);
	}
}
