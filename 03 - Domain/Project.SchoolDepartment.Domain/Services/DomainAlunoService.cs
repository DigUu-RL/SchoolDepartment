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

public class DomainAlunoService : IDomainAlunoService
{
	private readonly IAlunoRepository _alunoRepository;
	private readonly IMapper _mapper;

	public DomainAlunoService(IAlunoRepository alunoRepository, IMapper mapper)
	{
		_alunoRepository = alunoRepository;
		_mapper = mapper;
	}

	public async Task<PaginatedModel<AlunoModel>> GetAllAsync(int page, int quantity)
	{
		PaginatedList<Student> data = await _alunoRepository.GetAllAsync(page, quantity);

		var model = new PaginatedModel<AlunoModel>
		{
			Page = data.Page,
			Pages = data.Pages,
			Total = data.Total,
			Data = _mapper.Map<List<AlunoModel>>(data)
		};

		return model;
	}

	public async Task<AlunoModel> GetByGuidAsync(Guid guid)
	{
		Student? data = await _alunoRepository.GetByGuidAsync(guid);

		if (data is null)
			throw new GlobalException("Aluno não encontrado!", HttpStatusCode.NotFound);

		AlunoModel model = _mapper.Map<AlunoModel>(data);
		return model;
	}

	public async Task CreateAsync(AlunoRequest request)
	{
		var aluno = new Student
		{

		};

		await _alunoRepository.CreateAsync(aluno);
	}

	public async Task UpdateAsync(AlunoRequest request)
	{
		Student? data = await _alunoRepository.GetByGuidAsync(/*request.Guid*/Guid.NewGuid());

		if (data is null)
			throw new GlobalException("Aluno não encontrado!", HttpStatusCode.NotFound);

		// code ...

		await _alunoRepository.UpdateAsync(data);
	}

	public async Task DeleteAsync(Guid guid)
	{
		Student? data = await _alunoRepository.GetByGuidAsync(guid);

		if (data is null)
			throw new GlobalException("Aluno não encontrado!", HttpStatusCode.NotFound);

		await _alunoRepository.DeleteAsync(data);
	}
}
