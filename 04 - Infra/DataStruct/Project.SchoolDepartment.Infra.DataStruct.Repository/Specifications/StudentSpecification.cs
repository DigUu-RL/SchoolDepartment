using LinqSpecs;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Specifications;

public static class StudentSpecification
{
	public static Specification<Student> ByGuid(Guid guid)
	{
		return new AdHocSpecification<Student>(x => x.Guid == guid);
	}

	public static Specification<Student> ByCourse(Guid courseGuid)
	{
		return new AdHocSpecification<Student>(x => x.CourseGuid == courseGuid);
	}

	public static Specification<Student> BySchool(Guid schoolGuid)
	{
		return new AdHocSpecification<Student>(x => x.SchoolGuid == schoolGuid);
	}

	public static Specification<Student> ByCellphone(Cellphone cellphone)
	{
		return new AdHocSpecification<Student>(x => x.Cellphones != null && x.Cellphones.Contains(cellphone));
	}
}
