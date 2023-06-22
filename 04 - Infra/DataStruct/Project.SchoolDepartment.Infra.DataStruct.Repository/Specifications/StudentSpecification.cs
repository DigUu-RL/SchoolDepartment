using LinqSpecs;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Specifications;

public static class StudentSpecification
{
	public static Specification<Student> ById(Guid id)
	{
		return new AdHocSpecification<Student>(x => x.Id == id);
	}

	public static Specification<Student> ByCourse(Guid courseId)
	{
		return new AdHocSpecification<Student>(x => x.CourseId == courseId);
	}

	public static Specification<Student> BySchool(Guid schoolId)
	{
		return new AdHocSpecification<Student>(x => x.SchoolId == schoolId);
	}

	public static Specification<Student> ByCellphone(Cellphone cellphone)
	{
		return new AdHocSpecification<Student>(x => x.Cellphones != null && x.Cellphones.Contains(cellphone));
	}

	public static Specification<Student> ByGender(Gender gender)
	{
		return new AdHocSpecification<Student>(x => x.Gender == gender);
	}
}
