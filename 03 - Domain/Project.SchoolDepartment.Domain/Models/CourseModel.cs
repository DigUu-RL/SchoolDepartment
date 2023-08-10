namespace Project.SchoolDepartment.Domain.Models;

public record CourseModel(Guid Guid, string Name, ICollection<StudentModel>? Students, ICollection<SchoolModel>? Schools);
