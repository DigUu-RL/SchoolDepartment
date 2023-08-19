﻿using AutoMapper;
using Project.SchoolDepartment.Application.DTOs;
using Project.SchoolDepartment.Domain.Models;

namespace Project.SchoolDepartment.Application.AutoMapper;

public class DTOMapProfile : Profile
{
	public DTOMapProfile()
	{
		CreateMap(typeof(StudentModel), typeof(StudentDTO));
		CreateMap(typeof(CourseModel), typeof(CourseDTO));
		CreateMap(typeof(SchoolModel), typeof(SchoolDTO));
		CreateMap(typeof(CellphoneModel), typeof(CellphoneDTO));

		#region COLLECTIONS MAP

		CreateMap(typeof(ICollection<StudentModel>), typeof(ICollection<StudentDTO>));
		CreateMap(typeof(ICollection<CourseModel>), typeof(ICollection<CourseDTO>));
		CreateMap(typeof(ICollection<SchoolModel>), typeof(ICollection<SchoolDTO>));
		CreateMap(typeof(ICollection<CellphoneModel>), typeof(ICollection<CellphoneDTO>));

		#endregion

		#region PAGINATED'S MAP

		CreateMap(typeof(PaginatedModel<StudentModel>), typeof(PaginatedDTO<StudentDTO>));
		CreateMap(typeof(PaginatedModel<CourseModel>), typeof(PaginatedDTO<CourseDTO>));
		CreateMap(typeof(PaginatedModel<SchoolModel>), typeof(PaginatedDTO<SchoolDTO>));
		CreateMap(typeof(PaginatedModel<CellphoneModel>), typeof(PaginatedDTO<CellphoneDTO>));

		#endregion
	}
}
