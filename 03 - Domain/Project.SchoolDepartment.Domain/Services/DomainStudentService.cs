using AutoMapper;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;
using Project.SchoolDepartment.Infra.Middleware.Exceptions;
using System.Net;

namespace Project.SchoolDepartment.Domain.Services;

public class DomainStudentService : IDomainStudentService
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

	public async Task<StudentModel> GetByGuidAsync(Guid guid)
	{
		Student? data = await _studentRepository.GetByGuidAsync(guid) 
			?? throw new NotFoundException("Aluno não encontrado!");
		
		StudentModel model = _mapper.Map<StudentModel>(data);
		return model;
	}

	public async Task CreateAsync(StudentRequest request)
	{
		var aluno = new Student
		{

		};

		await _studentRepository.CreateAsync(aluno);
	}

	public async Task UpdateAsync(StudentRequest request)
	{
		Student? data = await _studentRepository.GetByGuidAsync(/*request.Guid*/Guid.NewGuid()) 
			?? throw new NotFoundException("Aluno não encontrado!");

		// code ...

		await _studentRepository.UpdateAsync(data);
	}

	public async Task DeleteAsync(Guid guid)
	{
		Student? data = await _studentRepository.GetByGuidAsync(guid) 
			?? throw new NotFoundException("Aluno não encontrado!");

		await _studentRepository.DeleteAsync(data);
	}

	public void Validate()
	{
		throw new NotImplementedException();
	}
}
