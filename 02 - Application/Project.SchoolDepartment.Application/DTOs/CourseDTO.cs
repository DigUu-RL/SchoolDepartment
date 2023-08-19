using Project.SchoolDepartment.Application.DTOs.Contratcts;

namespace Project.SchoolDepartment.Application.DTOs;

public record CourseDTO(Guid Id, string Name, ICollection<StudentDTO>? Students, ICollection<SchoolDTO>? Schools) : IDTO;
