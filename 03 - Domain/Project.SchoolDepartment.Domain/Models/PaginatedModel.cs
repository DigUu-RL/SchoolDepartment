namespace Project.SchoolDepartment.Domain.Models;

public record PaginatedModel<T>(int Page, int Pages, int Total, List<T>? Data);
