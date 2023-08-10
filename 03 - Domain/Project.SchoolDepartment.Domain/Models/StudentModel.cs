using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Domain.Models;

public record StudentModel
(
	string Name,
	string Lastname,
	string CPF,
	string RA,
	Gender Gender,
	string Street,
	string District,
	int Number,
	string City,
	string State,
	Guid CourseGuid,
	CourseModel? Course,
	Guid SchoolGuid,
	SchoolModel? School,
	ICollection<CellphoneModel>? Cellphones
);
