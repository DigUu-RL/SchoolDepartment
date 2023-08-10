using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Application.DTOs;

public record StudentDTO
(
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
	Guid? CourseId, 
	CourseDTO? Course, 
	Guid? SchoolId, 
	SchoolDTO? School, 
	ICollection<CellphoneDTO>? Cellphones
);
