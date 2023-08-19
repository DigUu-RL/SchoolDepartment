namespace Project.SchoolDepartment.Domain.Models;

public record CourseModel(Guid Id, string Name, ICollection<StudentModel>? Students, ICollection<SchoolModel>? Schools);
