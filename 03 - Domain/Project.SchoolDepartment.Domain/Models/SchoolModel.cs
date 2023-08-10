using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Domain.Models;

public record SchoolModel
(
	Guid Guid,
	Period Period,
	DateTime StartDate,
	DateTime EndDate,
	CourseModel? Course,
	ICollection<StudentModel>? Students
);
