using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Application.DTOs;

public record SchoolDTO(Guid Guid, Period Period, DateTime StartDate, DateTime EndDate, CourseDTO? Course, ICollection<StudentDTO>? Students);
