namespace Project.SchoolDepartment.Application.DTOs;

public record CourseDTO(Guid Guid, string Name, ICollection<StudentDTO>? Students, ICollection<SchoolDTO>? Schools);
