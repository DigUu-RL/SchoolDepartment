using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Domain.Models;

public class SchoolModel
{
	public Guid Guid { get; set; }
	public Period Period { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public CourseModel? Course { get; set; }
	public ICollection<StudentModel>? Students { get; set; }
}
