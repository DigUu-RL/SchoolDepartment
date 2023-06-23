using AutoMapper;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;
using Project.SchoolDepartment.Infra.Middleware.Exceptions;
using System.Net;
using InvalidDataException = Project.SchoolDepartment.Infra.Middleware.Exceptions.InvalidDataException;

namespace Project.SchoolDepartment.Domain.Services;

public class DomainStudentService : DomainServiceBase<StudentRequest>, IDomainStudentService
{
	private readonly IStudentRepository _studentRepository;
	private readonly IMapper _mapper;

	public DomainStudentService(IStudentRepository studentRepository, IMapper mapper)
	{
		_studentRepository = studentRepository;
		_mapper = mapper;
	}

	public async Task<PaginatedModel<StudentModel>> GetAllAsync(int page, int quantity)
	{
		PaginatedList<Student> data = await _studentRepository.GetAllAsync(page, quantity);

		var model = new PaginatedModel<StudentModel>
		{
			Page = data.Page,
			Pages = data.Pages,
			Total = data.Total,
			Data = _mapper.Map<List<StudentModel>>(data)
		};

		return model;
	}

	public async Task<StudentModel> GetByIdAsync(Guid guid)
	{
		Student? data = await _studentRepository.GetByIdAsync(guid) ?? throw new NotFoundException("Aluno não encontrado!");

		StudentModel model = _mapper.Map<StudentModel>(data);
		return model;
	}

	public async Task CreateAsync(StudentRequest request)
	{
		Validate(request);

		var student = new Student
		{
			Name = request.Name!,
			LastName = request!.LastName!,
			CPF = request.CPF!,
			RA = Util.RandomString(80),
			Gender = request.Gender,
			Street = request.Street!,
			District = request.District!,
			Number= request.Number,
			City = request.City!,
			State = request.State!,
			CourseId = null,
			SchoolId = null
		};

		await _studentRepository.CreateAsync(student);
		await _studentRepository.CommitAsync();
	}

	public async Task UpdateAsync(StudentRequest request)
	{
		Student? data = await _studentRepository.GetByIdAsync(request.Id)
			?? throw new NotFoundException("Aluno não encontrado!");

		// code ...

		await _studentRepository.UpdateAsync(data);
	}

	public async Task DeleteAsync(Guid guid)
	{
		Student? data = await _studentRepository.GetByIdAsync(guid)
			?? throw new NotFoundException("Aluno não encontrado!");

		await _studentRepository.DeleteAsync(data);
	}

	public override void Validate(StudentRequest request)
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
