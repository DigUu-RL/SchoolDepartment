using AutoMapper;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Domain.Models;

namespace Project.SchoolDepartment.Application.AutoMapper;

public class DTOMapProfile : Profile
{
	public DTOMapProfile()
	{
		CreateMap(typeof(AlunoModel), typeof(AlunoDTO));
		CreateMap(typeof(CursoModel), typeof(CursoDTO));
		CreateMap(typeof(TurmaModel), typeof(TurmaDTO));
		CreateMap(typeof(TelefoneModel), typeof(TelefoneDTO));

		#region PAGINATED'S

		CreateMap(typeof(PaginatedModel<AlunoModel>), typeof(PaginatedDTO<AlunoDTO>));
		CreateMap(typeof(PaginatedModel<CursoModel>), typeof(PaginatedDTO<CursoDTO>));
		CreateMap(typeof(PaginatedModel<TurmaModel>), typeof(PaginatedDTO<TurmaDTO>));
		CreateMap(typeof(PaginatedModel<TelefoneModel>), typeof(PaginatedDTO<TelefoneDTO>));

		#endregion
	}
}
