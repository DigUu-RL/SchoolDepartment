namespace Project.SchoolDepartment.Application.DTOs;

public record PaginatedDTO<T>(int Page, int Pages, int Total, List<T>? Data);
