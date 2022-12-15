using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Application.DTOs;

public class SchoolDTO
{
	public Guid Guid { get; set; }
	public Period Period { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public CourseDTO? Course { get; set; }
	public ICollection<StudentDTO>? Students { get; set; }
}
