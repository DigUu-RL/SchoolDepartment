using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.Specs;
using Project.SchoolDepartment.Infra.Specs.Contracts;

namespace Project.SchoolDepartment.Domain.Specs.Custom;

public static class StudentSpecfication
{
	public static Specification<Student> ById(Guid id)
	{
		return new ExpressionSpecification<Student>(x => x.Id == id);
	}
}
