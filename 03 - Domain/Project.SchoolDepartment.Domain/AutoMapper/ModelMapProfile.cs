using AutoMapper;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Domain.AutoMapper;

public class ModelMapProfile : Profile
{
	public ModelMapProfile()
	{
		CreateMap(typeof(Student), typeof(AlunoModel));
		CreateMap(typeof(Course), typeof(CursoModel));
		CreateMap(typeof(School), typeof(TurmaModel));
		CreateMap(typeof(Cellphone), typeof(TelefoneModel));
	}
}
