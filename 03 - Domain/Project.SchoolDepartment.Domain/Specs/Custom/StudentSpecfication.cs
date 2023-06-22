using Project.SchoolDepartment.Domain.Specs.Contracts;
using Project.SchoolDepartment.Domain.Specs.Interfaces;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;

namespace Project.SchoolDepartment.Domain.Specs.Custom;

public static class StudentSpecfication
{
	public static ISpecification<Student> ById(Guid id)
	{
		return new ExpressionSpecification<Student>(x => x.Id == id);
	}
}
