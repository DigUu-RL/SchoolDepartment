using LinqSpecs;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Specifications;

public static class StudentSpecification
{
	/// <summary>
	/// Find student by <see cref="Guid"/>
	/// </summary>
	/// <param name="guid"></param>
	/// <returns></returns>
	public static Specification<Student> ByGuid(Guid guid)
	{
		return new AdHocSpecification<Student>(x => x.Guid == guid);
	}

	/// <summary>
	/// Find student by course
	/// </summary>
	/// <param name="courseGuid"></param>
	/// <returns></returns>
	public static Specification<Student> ByCourse(Guid courseGuid)
	{
		return new AdHocSpecification<Student>(x => x.CourseGuid == courseGuid);
	}


	/// <summary>
	/// Find student by school
	/// </summary>
	/// <param name="schoolGuid"></param>
	/// <returns></returns>
	public static Specification<Student> BySchool(Guid schoolGuid)
	{
		return new AdHocSpecification<Student>(x => x.SchoolGuid == schoolGuid);
	}

	/// <summary>
	/// Find student by <see cref="Cellphone"/>
	/// </summary>
	/// <param name="cellphone"></param>
	/// <returns></returns>
	public static Specification<Student> ByCellphone(Cellphone cellphone)
	{
		return new AdHocSpecification<Student>(x => x.Cellphones != null && x.Cellphones.Contains(cellphone));
	}
}
