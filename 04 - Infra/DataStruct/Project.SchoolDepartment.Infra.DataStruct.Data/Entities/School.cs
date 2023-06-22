using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

public class School : EntityBase
{
	public Period Period { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }

	// relationships
	public Guid CourseId { get; set; }
	public Course? Course { get; set; }
	public ICollection<Student>? Students { get; set; }
}
