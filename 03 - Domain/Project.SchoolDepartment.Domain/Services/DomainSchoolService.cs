using AutoMapper;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Domain.Requests;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;
using Project.SchoolDepartment.Infra.Middleware.Exceptions;
using Project.SchoolDepartment.Infra.Specs;
using Project.SchoolDepartment.Infra.Specs.Contracts;

namespace Project.SchoolDepartment.Domain.Services;

public class DomainSchoolService : IDomainSchoolService
{
	private readonly ISchoolRepository _schoolRepository;
	private readonly IMapper _mapper;

	public DomainSchoolService(ISchoolRepository schoolRepository, IMapper mapper)
	{
		_schoolRepository = schoolRepository;
		_mapper = mapper;
	}

	public async Task<PaginatedModel<SchoolModel>> GetAsync(Search<SchoolRequest> search)
	{
		Specification<School> specification = new TrueSpecification<School>();

		if (search.Filter is not null)
		{
			// filters goes here
		}

		PaginatedList<School> data = await _schoolRepository.GetAsync(search.Page, search.Quantity, specification);
		return new PaginatedModel<SchoolModel>(data.Page, data.Pages, data.Total, _mapper.Map<List<SchoolModel>>(data));
	}

	public async Task<SchoolModel> GetByIdAsync(Guid id)
	{
		School school = await _schoolRepository.GetByIdAsync(id) ?? throw new NotFoundException("Turma não encontrada!");
		return _mapper.Map<SchoolModel>(school);
	}

	public async Task CreateAsync(SchoolRequest request)
	{
		// request validation fields goes here ...
		var school = new School
		{

		};

		await _schoolRepository.CreateAsync(school);
		await _schoolRepository.CommitAsync();
	}

	public async Task UpdateAsync(SchoolRequest request)
	{
		School school = await _schoolRepository.GetByIdAsync(request.Id ?? Guid.Empty) ?? throw new NotFoundException("Turma não encontrada!");

		// request validation fields goes here ...
		// update entity here ...

		await _schoolRepository.UpdateAsync(school);
		await _schoolRepository.CommitAsync();
	}

	public async Task DeleteAsync(Guid id)
	{
		School school = await _schoolRepository.GetByIdAsync(id) ?? throw new NotFoundException("Turma não encontrada!");

		await _schoolRepository.DeleteAsync(school);
		await _schoolRepository.CommitAsync();
	}
}
