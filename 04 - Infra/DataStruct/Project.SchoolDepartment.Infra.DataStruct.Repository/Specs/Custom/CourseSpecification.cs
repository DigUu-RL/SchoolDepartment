using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.Specs;
using Project.SchoolDepartment.Infra.Specs.Contracts;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Specs.Custom;

public static class CourseSpecification
{
	/// <summary>
	/// Get <see cref="Course"/> by id
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public static Specification<Course> ById(Guid id)
	{
		return new ExpressionSpecification<Course>(x => x.Id == id);
	}

	/// <summary>
	/// Get <see cref="Course"/> by <see cref="Course.Name"/>
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public static Specification<Course> ByName(string name)
	{
		return new ExpressionSpecification<Course>(x => x.Name == name);
	}

	/// <summary>
	/// Get <see cref="Course"/> by <see cref="Student"/> id
	/// </summary>
	/// <param name="studentId"></param>
	/// <returns></returns>
	public static Specification<Course> ByStudentId(Guid studentId)
	{
		return new ExpressionSpecification<Course>(x => x.Students != null && x.Students.Any(y => y.Id == studentId));
	}

	/// <summary>
	/// Get <see cref="Course"/> by <see cref="Student"/>
	/// </summary>
	/// <param name="student"></param>
	/// <returns></returns>
	public static Specification<Course> ByStudent(Student student)
	{
		return new ExpressionSpecification<Course>(x => x.Students != null && x.Students.Contains(student));
	}

	/// <summary>
	/// Get <see cref="Course"/> by <see cref="School"/> id
	/// </summary>
	/// <param name="schoolId"></param>
	/// <returns></returns>
	public static Specification<Course> BySchoolId(Guid schoolId)
	{
		return new ExpressionSpecification<Course>(x => x.Schools != null && x.Schools.Any(y => y.Id == schoolId));
	}

	/// <summary>
	/// Get <see cref="Course"/> by <see cref="School"/>
	/// </summary>
	/// <param name="schoolId"></param>
	/// <returns></returns>
	public static Specification<Course> BySchool(School school)
	{
		return new ExpressionSpecification<Course>(x => x.Schools != null && x.Schools.Contains(school));
	}
}
