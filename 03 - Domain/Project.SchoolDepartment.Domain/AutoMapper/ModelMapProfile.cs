using AutoMapper;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Domain.AutoMapper;

public class ModelMapProfile : Profile
{
	public ModelMapProfile()
	{
		CreateMap(typeof(Aluno), typeof(AlunoModel));
		CreateMap(typeof(Curso), typeof(CursoModel));
		CreateMap(typeof(Turma), typeof(TurmaModel));
		CreateMap(typeof(Telefone), typeof(TelefoneModel));
	}
}
