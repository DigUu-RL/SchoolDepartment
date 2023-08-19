using Project.SchoolDepartment.Domain.Models.Contracts;

namespace Project.SchoolDepartment.Domain.Models;

public record PaginatedModel<T>(int Page, int Pages, int Total, List<T>? Data) : IModel;
