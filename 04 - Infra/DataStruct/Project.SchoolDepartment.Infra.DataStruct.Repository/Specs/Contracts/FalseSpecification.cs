using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Contracts;

public sealed class FalseSpecification<TClass> : Specification<TClass> where TClass : class
{
	public FalseSpecification()
	{
	}

	public override Expression<Func<TClass, bool>> ToExpression()
	{
		return (TClass x) => false;
	}
}
