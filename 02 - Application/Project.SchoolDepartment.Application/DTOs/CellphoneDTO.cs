namespace Project.SchoolDepartment.Application.DTOs;

public record CellphoneDTO(Guid Id, string? Number, Guid? StudentId, StudentDTO? Student);
