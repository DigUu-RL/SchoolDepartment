using AutoMapper;
using Project.SchoolDepartment.Domain.Models;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Domain.AutoMapper;

public class ModelMapProfile : Profile
{
	public ModelMapProfile()
	{
		CreateMap(typeof(Student), typeof(StudentModel));
		CreateMap(typeof(Course), typeof(CourseModel));
		CreateMap(typeof(School), typeof(SchoolModel));
		CreateMap(typeof(Cellphone), typeof(CellphoneModel));
	}
}
