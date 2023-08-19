using Project.SchoolDepartment.Domain.Models.Contracts;

namespace Project.SchoolDepartment.Domain.Models;

public record CellphoneModel(Guid Id, string? Number, Guid? StudentId, StudentModel? Student) : IModel;
