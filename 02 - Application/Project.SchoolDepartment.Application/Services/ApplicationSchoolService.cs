using AutoMapper;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Application.Services;

public class ApplicationSchoolService : IApplicationSchoolService
{
	private readonly IDomainSchoolService _schoolService;
	private readonly IMapper _mapper;

	public ApplicationSchoolService(IDomainSchoolService schoolService, IMapper mapper)
	{
		_schoolService = schoolService;
		_mapper = mapper;
	}

	public async Task<PaginatedDTO<SchoolDTO>> GetAsync(Search<SchoolRequest> search)
	{
		PaginatedDTO<SchoolDTO> data = _mapper.Map<PaginatedDTO<SchoolDTO>>(await _schoolService.GetAsync(search));
		return data;
	}

	public async Task<SchoolDTO> GetByIdAsync(Guid id)
	{
		SchoolDTO data = _mapper.Map<SchoolDTO>(await _schoolService.GetByIdAsync(id));
		return data;
	}

	public async Task CreateAsync(SchoolRequest request)
	{
		await _schoolService.CreateAsync(request);
	}

	public async Task UpdateAsync(SchoolRequest request)
	{
		await _schoolService.UpdateAsync(request);
	}

	public async Task DeleteAsync(Guid id)
	{
		await _schoolService.DeleteAsync(id);
	}

	public void Validate(SchoolRequest request)
	{
		throw new NotImplementedException();
	}
}
