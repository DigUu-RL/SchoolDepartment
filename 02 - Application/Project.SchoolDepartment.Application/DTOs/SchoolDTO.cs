using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Application.DTOs;

public record SchoolDTO(
	Guid Id, 
	Period Period, 
	DateTime StartDate, 
	DateTime EndDate, 
	Guid? CourseId, 
	CourseDTO? Course, 
	ICollection<StudentDTO>? Students
);
