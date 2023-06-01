using LinqSpecs;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;

public static class SpecificationExtensions
{
	public static Func<T, bool> CompileExpression<T>(this Specification<T> specification)
	{
		return specification.ToExpression().Compile();
	}
}
