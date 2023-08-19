using Project.SchoolDepartment.Domain.Models.Contracts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Domain.Models;

public record SchoolModel
(
	Guid Id,
	Period Period,
	DateTime StartDate,
	DateTime EndDate,
	Guid? CourseId,
	CourseModel? Course,
	ICollection<StudentModel>? Students
) : IModel;
