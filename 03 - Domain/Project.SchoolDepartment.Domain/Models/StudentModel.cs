using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Domain.Models;

public record StudentModel
(
	Guid Id,
	string Name,
	string LastName,
	string CPF,
	string RA,
	Gender Gender,
	string Street,
	string District,
	int Number,
	string City,
	string State,
	Guid CourseId,
	CourseModel? Course,
	Guid SchoolId,
	SchoolModel? School,
	ICollection<CellphoneModel>? Cellphones
);
