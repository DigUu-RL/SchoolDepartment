using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Abstractions;

public sealed class TrueSpecification<T> : Specification<T>
{
	public TrueSpecification()
	{
	}

	public override Expression<Func<T, bool>> ToExpression()
	{
		return (T x) => true;
	}
}
