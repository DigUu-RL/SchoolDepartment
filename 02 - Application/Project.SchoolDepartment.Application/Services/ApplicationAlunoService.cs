using AutoMapper;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Application.Interfaces;
using Project.SchoolDepartment.Domain.Interfaces;
using Project.SchoolDepartment.Domain.Requests;

namespace Project.SchoolDepartment.Application.Services;

public class ApplicationAlunoService : IApplicationAlunoService
{
	private readonly IDomainAlunoService _alunoService;
	private readonly IMapper _mapper;

	public ApplicationAlunoService(IDomainAlunoService alunoService, IMapper mapper)
	{
		_alunoService = alunoService;
		_mapper = mapper;
	}

	public async Task<PaginatedDTO<AlunoDTO>> GetAllAsync(int page, int quantity)
	{
		PaginatedDTO<AlunoDTO> data = _mapper.Map<PaginatedDTO<AlunoDTO>>(await _alunoService.GetAllAsync(page, quantity));
		return data;
	}

	public async Task<AlunoDTO> GetByIdAsync(Guid id)
	{
		AlunoDTO data = _mapper.Map<AlunoDTO>(await _alunoService.GetByGuidAsync(id));
		return data;
	}

	public async Task CreateAsync(AlunoRequest request)
	{
		await _alunoService.CreateAsync(request);
	}

	public async Task UpdateAsync(AlunoRequest request)
	{
		await _alunoService.UpdateAsync(request);
	}

	public async Task DeleteAsync(Guid id)
	{
		await _alunoService.DeleteAsync(id);
	}
}
